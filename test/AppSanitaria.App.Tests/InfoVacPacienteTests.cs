using Xunit;
using System;
using Sanitaria;

using Sanitaria.Modelos;

namespace Sanitaria
{

    public class InfoVacPacienteTests
    {
        [Fact]
        public void EstadoDeVacunacion_NoVacunado_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 1,
                FechaUltimaDosis = new DateTime(2021, 5, 1)
            };
            // When
            var resultado = p1.EstadoDeVacunacion;
            // Then
            Assert.Equal(PautaVacunacion.NoVacunado, resultado);
        }
        [Fact]
        public void EstadoDeVacunacion_Incompleta_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Astra,
                DosisRecibidas = 1,
                FechaUltimaDosis = DateTime.Now.AddDays(-15)
            };
            // When
            var resultado = p1.EstadoDeVacunacion;
            // Then
            Assert.Equal(PautaVacunacion.Incompleta, resultado);
        }
        [Fact]
        public void EstadoDeVacunacion_Completa_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Moderna,
                DosisRecibidas = 2,
                FechaUltimaDosis = DateTime.Now.AddDays(-15)
            };
            // When
            var resultado = p1.EstadoDeVacunacion;
            // Then
            Assert.Equal(PautaVacunacion.Completa, resultado);
        }

    }
}
