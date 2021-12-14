using Xunit;
using System;
using Sanitaria;

using Sanitaria.Modelos;

namespace Sanitaria
{

    public class GestorDeUrgenciasTests
    {

        [Fact]
        public void VacunacionDelPaciente_NoVacunado_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 1,
                FechaUltimaDosis = new DateTime(2021, 5, 1)
            };
            GestorDeUrgencias urgencias = new GestorDeUrgencias();
            // When
            var resultado = urgencias.VacunacionDelPaciente(p1);
            // Then
            Assert.Equal(PautaVacunacion.NoVacunado, resultado);
        }
        [Fact]
        public void VacunacionDelPaciente_Completa_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.JandJ,
                DosisRecibidas = 1,
                FechaUltimaDosis = DateTime.Now.AddDays(-15)
            };
            GestorDeUrgencias urgencias = new GestorDeUrgencias();
            // When
            var resultado = urgencias.VacunacionDelPaciente(p1);
            // Then
            Assert.Equal(PautaVacunacion.Completa, resultado);
        }
        [Fact]
        public void VacunacionDelPaciente_Incompleta_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.JandJ,
                DosisRecibidas = 1,
                FechaUltimaDosis = DateTime.Now.AddDays(-10)
            };
            GestorDeUrgencias urgencias = new GestorDeUrgencias();
            // When
            var resultado = urgencias.VacunacionDelPaciente(p1);
            // Then
            Assert.Equal(PautaVacunacion.Incompleta, resultado);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, true, true, true)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]
        public void RealizacionDePCR_Test(bool sintomas, bool inmunodepresion, bool pautaCompleta, bool pcrEsperado)
        {
            //
            var urgencias = new GestorDeUrgencias();
            //
            var resultado = urgencias.RealizacionDePCR(sintomas, inmunodepresion, pautaCompleta);
            //
            Assert.Equal(pcrEsperado, resultado);
        }
    }
}
