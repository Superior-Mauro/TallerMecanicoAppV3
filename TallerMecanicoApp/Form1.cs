using System.ComponentModel;
using TallerMecanicoApp.Data;
using TallerMecanicoApp.Helpers;
using TallerMecanicoApp.Models;

namespace TallerMecanicoApp;

public partial class Form1 : Form
{
    private readonly TallerRepository _repositorio = new();
    private readonly BindingList<Vehiculo> _vehiculos;

    public Form1()
    {
        InitializeComponent();
        _vehiculos = new BindingList<Vehiculo>();
        dgvVehiculos.AutoGenerateColumns = false;
        dgvVehiculos.DataSource = _vehiculos;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        CargarVehiculos();
    }

    private void btnRegistrarVehiculo_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCliente.Text) ||
            string.IsNullOrWhiteSpace(txtModelo.Text) ||
            string.IsNullOrWhiteSpace(txtProblema.Text))
        {
            MessageBox.Show("Completa todos los campos para registrar el vehículo.", "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!PlacaValidator.EsValida(txtPlaca.Text, out var mensajePlaca))
        {
            MessageBox.Show(mensajePlaca, "Validación",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPlaca.Focus();
            return;
        }

        var placa = PlacaValidator.Normalizar(txtPlaca.Text);

        try
        {
            if (_repositorio.ExistePlaca(placa))
            {
                MessageBox.Show("La placa ya está registrada.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var vehiculo = new Vehiculo(
                placa,
                txtCliente.Text.Trim(),
                txtModelo.Text.Trim(),
                txtProblema.Text.Trim(),
                txtTelefono.Text.Trim());

            _repositorio.RegistrarVehiculo(vehiculo);
            CargarVehiculos();
            LimpiarCamposVehiculo();
        }
        catch (Exception ex)
        {
            MostrarErrorBaseDatos(ex);
        }
    }

    private void btnRegistroTrabajos_Click(object sender, EventArgs e)
    {
        CargarVehiculos();

        if (_vehiculos.Count == 0)
        {
            MessageBox.Show("Debes registrar al menos un vehículo para asignar trabajos.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var placaSeleccionada = dgvVehiculos.CurrentRow?.DataBoundItem is Vehiculo vehiculo
            ? vehiculo.Placa
            : null;

        using var formTrabajos = new Form2(placaSeleccionada);
        formTrabajos.ShowDialog(this);
    }

    private void CargarVehiculos()
    {
        try
        {
            _vehiculos.Clear();
            foreach (var vehiculo in _repositorio.ObtenerVehiculos())
            {
                _vehiculos.Add(vehiculo);
            }
        }
        catch (Exception ex)
        {
            MostrarErrorBaseDatos(ex);
        }
    }

    private void LimpiarCamposVehiculo()
    {
        txtPlaca.Clear();
        txtCliente.Clear();
        txtTelefono.Clear();
        txtModelo.Clear();
        txtProblema.Clear();
        txtPlaca.Focus();
    }

    private static void MostrarErrorBaseDatos(Exception ex)
    {
        MessageBox.Show(
            $"No se pudo conectar o guardar en SQL Server.{Environment.NewLine}{Environment.NewLine}{ex.Message}",
            "Base de datos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
