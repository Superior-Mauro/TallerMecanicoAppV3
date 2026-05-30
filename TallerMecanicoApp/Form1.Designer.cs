namespace TallerMecanicoApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblTitulo = new Label();
        gbRecepcion = new GroupBox();
        txtProblema = new TextBox();
        txtModelo = new TextBox();
        txtTelefono = new TextBox();
        txtCliente = new TextBox();
        txtPlaca = new TextBox();
        lblProblema = new Label();
        lblModelo = new Label();
        lblTelefono = new Label();
        lblCliente = new Label();
        lblPlaca = new Label();
        btnRegistrarVehiculo = new Button();
        btnRegistroTrabajos = new Button();
        dgvVehiculos = new DataGridView();
        colPlaca = new DataGridViewTextBoxColumn();
        colCliente = new DataGridViewTextBoxColumn();
        colModelo = new DataGridViewTextBoxColumn();
        colProblema = new DataGridViewTextBoxColumn();
        gbRecepcion.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.Location = new Point(22, 18);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(258, 25);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Recepción - Taller Mecánico";
        // 
        // gbRecepcion
        // 
        gbRecepcion.Controls.Add(txtProblema);
        gbRecepcion.Controls.Add(txtModelo);
        gbRecepcion.Controls.Add(txtTelefono);
        gbRecepcion.Controls.Add(txtCliente);
        gbRecepcion.Controls.Add(txtPlaca);
        gbRecepcion.Controls.Add(lblProblema);
        gbRecepcion.Controls.Add(lblModelo);
        gbRecepcion.Controls.Add(lblTelefono);
        gbRecepcion.Controls.Add(lblCliente);
        gbRecepcion.Controls.Add(lblPlaca);
        gbRecepcion.Location = new Point(24, 56);
        gbRecepcion.Name = "gbRecepcion";
        gbRecepcion.Size = new Size(845, 150);
        gbRecepcion.TabIndex = 1;
        gbRecepcion.TabStop = false;
        gbRecepcion.Text = "Datos de ingreso";
        // 
        // txtProblema
        // 
        txtProblema.Location = new Point(92, 110);
        txtProblema.Name = "txtProblema";
        txtProblema.Size = new Size(734, 23);
        txtProblema.TabIndex = 7;
        // 
        // txtModelo
        // 
        txtModelo.Location = new Point(92, 77);
        txtModelo.Name = "txtModelo";
        txtModelo.Size = new Size(282, 23);
        txtModelo.TabIndex = 6;
        // 
        // txtTelefono
        // 
        txtTelefono.Location = new Point(544, 77);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(282, 23);
        txtTelefono.TabIndex = 8;
        // 
        // txtCliente
        // 
        txtCliente.Location = new Point(544, 35);
        txtCliente.Name = "txtCliente";
        txtCliente.Size = new Size(282, 23);
        txtCliente.TabIndex = 5;
        // 
        // txtPlaca
        // 
        txtPlaca.CharacterCasing = CharacterCasing.Upper;
        txtPlaca.Location = new Point(92, 35);
        txtPlaca.MaxLength = 15;
        txtPlaca.Name = "txtPlaca";
        txtPlaca.Size = new Size(282, 23);
        txtPlaca.TabIndex = 4;
        // 
        // lblProblema
        // 
        lblProblema.AutoSize = true;
        lblProblema.Location = new Point(24, 113);
        lblProblema.Name = "lblProblema";
        lblProblema.Size = new Size(61, 15);
        lblProblema.TabIndex = 3;
        lblProblema.Text = "Problema:";
        // 
        // lblModelo
        // 
        lblModelo.AutoSize = true;
        lblModelo.Location = new Point(0, 80);
        lblModelo.Name = "lblModelo";
        lblModelo.Size = new Size(95, 15);
        lblModelo.TabIndex = 2;
        lblModelo.Text = "Marca / Modelo:";
        // 
        // lblTelefono
        // 
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(470, 80);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(55, 15);
        lblTelefono.TabIndex = 4;
        lblTelefono.Text = "Teléfono:";
        // 
        // lblCliente
        // 
        lblCliente.AutoSize = true;
        lblCliente.Location = new Point(482, 38);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(47, 15);
        lblCliente.TabIndex = 1;
        lblCliente.Text = "Cliente:";
        // 
        // lblPlaca
        // 
        lblPlaca.AutoSize = true;
        lblPlaca.Location = new Point(47, 38);
        lblPlaca.Name = "lblPlaca";
        lblPlaca.Size = new Size(38, 15);
        lblPlaca.TabIndex = 0;
        lblPlaca.Text = "Placa:";
        // 
        // btnRegistrarVehiculo
        // 
        btnRegistrarVehiculo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRegistrarVehiculo.Location = new Point(24, 218);
        btnRegistrarVehiculo.Name = "btnRegistrarVehiculo";
        btnRegistrarVehiculo.Size = new Size(147, 33);
        btnRegistrarVehiculo.TabIndex = 2;
        btnRegistrarVehiculo.Text = "Registrar vehículo";
        btnRegistrarVehiculo.UseVisualStyleBackColor = true;
        btnRegistrarVehiculo.Click += btnRegistrarVehiculo_Click;
        // 
        // btnRegistroTrabajos
        // 
        btnRegistroTrabajos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRegistroTrabajos.Location = new Point(186, 218);
        btnRegistroTrabajos.Name = "btnRegistroTrabajos";
        btnRegistroTrabajos.Size = new Size(147, 33);
        btnRegistroTrabajos.TabIndex = 3;
        btnRegistroTrabajos.Text = "Registro de trabajos";
        btnRegistroTrabajos.UseVisualStyleBackColor = true;
        btnRegistroTrabajos.Click += btnRegistroTrabajos_Click;
        // 
        // dgvVehiculos
        // 
        dgvVehiculos.AllowUserToAddRows = false;
        dgvVehiculos.AllowUserToDeleteRows = false;
        dgvVehiculos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvVehiculos.Columns.AddRange(new DataGridViewColumn[] { colPlaca, colCliente, colModelo, colProblema });
        dgvVehiculos.Location = new Point(24, 265);
        dgvVehiculos.MultiSelect = false;
        dgvVehiculos.Name = "dgvVehiculos";
        dgvVehiculos.ReadOnly = true;
        dgvVehiculos.RowHeadersVisible = false;
        dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvVehiculos.Size = new Size(845, 254);
        dgvVehiculos.TabIndex = 4;
        // 
        // colPlaca
        // 
        colPlaca.DataPropertyName = "Placa";
        colPlaca.HeaderText = "Placa";
        colPlaca.Name = "colPlaca";
        colPlaca.ReadOnly = true;
        colPlaca.Width = 120;
        // 
        // colCliente
        // 
        colCliente.DataPropertyName = "Cliente";
        colCliente.HeaderText = "Cliente";
        colCliente.Name = "colCliente";
        colCliente.ReadOnly = true;
        colCliente.Width = 220;
        // 
        // colModelo
        // 
        colModelo.DataPropertyName = "Modelo";
        colModelo.HeaderText = "Modelo";
        colModelo.Name = "colModelo";
        colModelo.ReadOnly = true;
        colModelo.Width = 220;
        // 
        // colProblema
        // 
        colProblema.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colProblema.DataPropertyName = "Problema";
        colProblema.HeaderText = "Problema reportado";
        colProblema.Name = "colProblema";
        colProblema.ReadOnly = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(892, 541);
        Controls.Add(dgvVehiculos);
        Controls.Add(btnRegistroTrabajos);
        Controls.Add(btnRegistrarVehiculo);
        Controls.Add(gbRecepcion);
        Controls.Add(lblTitulo);
        MinimumSize = new Size(908, 580);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestión de Taller Mecánico";
        Load += Form1_Load;
        gbRecepcion.ResumeLayout(false);
        gbRecepcion.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private GroupBox gbRecepcion;
    private TextBox txtProblema;
    private TextBox txtModelo;
    private TextBox txtTelefono;
    private TextBox txtCliente;
    private TextBox txtPlaca;
    private Label lblProblema;
    private Label lblModelo;
    private Label lblTelefono;
    private Label lblCliente;
    private Label lblPlaca;
    private Button btnRegistrarVehiculo;
    private Button btnRegistroTrabajos;
    private DataGridView dgvVehiculos;
    private DataGridViewTextBoxColumn colPlaca;
    private DataGridViewTextBoxColumn colCliente;
    private DataGridViewTextBoxColumn colModelo;
    private DataGridViewTextBoxColumn colProblema;
}
