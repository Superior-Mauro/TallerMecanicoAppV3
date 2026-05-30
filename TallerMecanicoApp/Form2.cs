using System.ComponentModel;
using TallerMecanicoApp.Data;
using TallerMecanicoApp.Models;

namespace TallerMecanicoApp;

public partial class Form2 : Form
{
    private readonly TallerRepository _repositorio = new();
    private readonly BindingList<Trabajo> _trabajos;
    private readonly BindingList<Vehiculo> _vehiculos = new();
    private readonly BindingList<Mecanico> _mecanicos = new();
    private readonly BindingSource _vehiculosBindingSource = new();
    private readonly BindingSource _mecanicosBindingSource = new();
    private readonly List<Servicio> _servicios;
    private readonly string? _placaPreseleccionada;

    public Form2(string? placaPreseleccionada = null)
    {
        InitializeComponent();
        _placaPreseleccionada = placaPreseleccionada;
        _trabajos = new BindingList<Trabajo>();
        _servicios = CatalogoServicios.ObtenerTodos();

        dgvTrabajos.AutoGenerateColumns = false;
        dgvTrabajos.DataSource = _trabajos;

        _vehiculosBindingSource.DataSource = _vehiculos;
        cbPlaca.DataSource = _vehiculosBindingSource;
        cbPlaca.DisplayMember = nameof(Vehiculo.Placa);
        cbPlaca.ValueMember = nameof(Vehiculo.Id);

        _mecanicosBindingSource.DataSource = _mecanicos;
        cbMecanico.DataSource = _mecanicosBindingSource;
        cbMecanico.DisplayMember = nameof(Mecanico.Nombre);
        cbMecanico.ValueMember = nameof(Mecanico.Id);
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        ConfigurarControles();
        CargarDatos();
    }

    private void ConfigurarControles()
    {
        cbServicio.DataSource = _servicios;
        cbServicio.DisplayMember = nameof(Servicio.Nombre);
        cbServicio.ValueMember = nameof(Servicio.Nombre);

        cbEstado.Items.AddRange(new object[]
        {
            "Pendiente",
            "En proceso",
            "Finalizado"
        });
        cbEstado.SelectedIndex = 0;
        cbServicio.SelectedIndex = 0;
    }

    private void CargarDatos()
    {
        try
        {
            var placaActual = ObtenerPlacaSeleccionada();
            _vehiculos.Clear();
            foreach (var vehiculo in _repositorio.ObtenerVehiculos())
            {
                _vehiculos.Add(vehiculo);
            }

            CargarMecanicos();

            if (cbMecanico.Items.Count > 0)
            {
                cbMecanico.SelectedIndex = 0;
            }

            SeleccionarPlaca(placaActual ?? _placaPreseleccionada);

            _trabajos.Clear();
            foreach (var trabajo in _repositorio.ObtenerTrabajos())
            {
                _trabajos.Add(trabajo);
            }

            RecalcularTotales();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"No se pudieron cargar los datos desde SQL Server.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                "Base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void CargarMecanicos()
    {
        _mecanicos.Clear();
        var id = 1;
        foreach (var nombre in CatalogoMecanicos.Nombres)
        {
            _mecanicos.Add(new Mecanico { Id = id++, Nombre = nombre });
        }
    }

    private void SeleccionarPlaca(string? placa)
    {
        if (string.IsNullOrWhiteSpace(placa) || _vehiculos.Count == 0)
        {
            if (_vehiculos.Count > 0)
            {
                cbPlaca.SelectedIndex = 0;
            }

            return;
        }

        var vehiculo = _vehiculos.FirstOrDefault(v =>
            v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));

        if (vehiculo is null)
        {
            cbPlaca.SelectedIndex = 0;
            return;
        }

        cbPlaca.SelectedValue = vehiculo.Id;
    }

    private string? ObtenerPlacaSeleccionada()
    {
        return cbPlaca.SelectedItem is Vehiculo vehiculo ? vehiculo.Placa : null;
    }

    private void btnRegistrarTrabajo_Click(object sender, EventArgs e)
    {
        if (cbPlaca.SelectedItem is not Vehiculo vehiculoSeleccionado)
        {
            MessageBox.Show("Selecciona una placa válida.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cbServicio.SelectedItem is not Servicio servicioSeleccionado)
        {
            MessageBox.Show("Selecciona un servicio.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
        {
            MessageBox.Show("Ingresa una descripción del trabajo.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cbMecanico.SelectedItem is not Mecanico mecanicoSeleccionado)
        {
            MessageBox.Show("Selecciona un mecánico.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var total = servicioSeleccionado.PrecioBase;
        var tiempo = servicioSeleccionado.TiempoBase;

        if (chkRefrigerante.Checked)
        {
            total += 90m;
            tiempo += TimeSpan.FromMinutes(40);
        }

        if (chkLiquidoFrenos.Checked)
        {
            total += 50m;
            tiempo += TimeSpan.FromMinutes(30);
        }

        var aplicaCambioBujias = servicioSeleccionado.Nombre is "Mantenimiento Simple" or "Mantenimiento Regular";
        var cambioBujias = chkBujias.Checked && aplicaCambioBujias;

        if (cambioBujias)
        {
            total += 40m;
            tiempo += TimeSpan.FromMinutes(10);
        }

        var trabajo = new Trabajo
        {
            Placa = vehiculoSeleccionado.Placa,
            Mecanico = mecanicoSeleccionado.Nombre,
            Descripcion = txtDescripcion.Text.Trim(),
            Estado = cbEstado.Text,
            ServicioNombre = servicioSeleccionado.Nombre,
            PrecioBase = servicioSeleccionado.PrecioBase,
            TiempoBase = servicioSeleccionado.TiempoBase,
            CambioRefrigerante = chkRefrigerante.Checked,
            CambioLiquidoFrenos = chkLiquidoFrenos.Checked,
            CambioBujias = cambioBujias,
            TotalPagar = total,
            TiempoEstimado = tiempo
        };

        try
        {
            _repositorio.RegistrarTrabajo(trabajo);
            CargarDatos();
            LimpiarFormulario();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"No se pudo guardar el trabajo en SQL Server.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
                "Base de datos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void cbServicio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbServicio.SelectedItem is not Servicio servicioSeleccionado)
        {
            return;
        }

        var texto = $"{servicioSeleccionado.Detalle} | Base: S/{servicioSeleccionado.PrecioBase:0.00} - {FormatearTiempo(servicioSeleccionado.TiempoBase)}";
        lblResumenServicio.Text = texto;

        var aplicaBujias = servicioSeleccionado.Nombre is "Mantenimiento Simple" or "Mantenimiento Regular";
        chkBujias.Enabled = aplicaBujias;
        if (!aplicaBujias)
        {
            chkBujias.Checked = false;
        }

        RecalcularTotales();
    }

    private void chkAdicional_CheckedChanged(object sender, EventArgs e)
    {
        RecalcularTotales();
    }

    private void RecalcularTotales()
    {
        if (cbServicio.SelectedItem is not Servicio servicioSeleccionado)
        {
            lblTotal.Text = "Total: S/0.00";
            lblTiempoEstimado.Text = "Tiempo estimado: 0h 0m";
            return;
        }

        var total = servicioSeleccionado.PrecioBase;
        var tiempo = servicioSeleccionado.TiempoBase;

        if (chkRefrigerante.Checked)
        {
            total += 90m;
            tiempo += TimeSpan.FromMinutes(40);
        }

        if (chkLiquidoFrenos.Checked)
        {
            total += 50m;
            tiempo += TimeSpan.FromMinutes(30);
        }

        if (chkBujias.Checked && chkBujias.Enabled)
        {
            total += 40m;
            tiempo += TimeSpan.FromMinutes(10);
        }

        lblTotal.Text = $"Total: S/{total:0.00}";
        lblTiempoEstimado.Text = $"Tiempo estimado: {FormatearTiempo(tiempo)}";
    }

    private static string FormatearTiempo(TimeSpan tiempo)
    {
        return $"{(int)tiempo.TotalHours}h {tiempo.Minutes}m";
    }

    private void LimpiarFormulario()
    {
        txtDescripcion.Clear();
        chkRefrigerante.Checked = false;
        chkLiquidoFrenos.Checked = false;
        chkBujias.Checked = false;
        cbEstado.SelectedIndex = 0;
        RecalcularTotales();
    }
}
