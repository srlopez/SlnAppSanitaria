using Xunit;
using System;
using Sanitaria;

using Sanitaria.Modelos;

using System.Collections.Generic;

namespace Santitaria.Data{
    public class FakeRepository : Sanitaria.Data.IData
    {
        public void Guardar(List<InfoVacPaciente> ingresados)
        {
            throw new NotImplementedException();
        }

        public List<InfoVacPaciente> Leer()
        {
            throw new NotImplementedException();
        }
    }
}
namespace Sanitaria
{
    using Sanitaria.Data;

    public class GestorDeUrgenciasTests
    {

        [Fact]
        public void Registro_Y_Alta_Test()
        {
            // Realmente de debe probar cada función por separado
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 1,
                FechaUltimaDosis = new DateTime(2021, 5, 1),
                Edad = 28,
                Sexo = 'H'
            };
            var sistema = new GestorDeUrgencias(new Santitaria.Data.FakeRepository());
            var cuenta = sistema.Ingresados.Count;
            // When
            sistema.RealizarIngreso(p1);
            var cuentaMas1 = sistema.Ingresados.Count;
            // Then
            Assert.Equal(cuenta + 1, cuentaMas1);
            // When
            sistema.DarDeAlta(p1);
            var cuentaMenos1 = sistema.Ingresados.Count;
            // Then
            Assert.Equal(cuenta, cuentaMenos1);
        }
        [Fact]
        public void VacunacionDelPaciente_NoVacunado_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Ninguna,
                DosisRecibidas = 1,
                FechaUltimaDosis = new DateTime(2021, 5, 1),
                Edad = 28,
                Sexo = 'H'
            };
            InfoVacPaciente p2 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Astra,
                DosisRecibidas = 0,
                FechaUltimaDosis = new DateTime(2021, 5, 1),
                Edad = 28,
                Sexo = 'H'
            };
            GestorDeUrgencias urgencias = new GestorDeUrgencias(new Santitaria.Data.FakeRepository());
            // When
            var resultado1 = urgencias.VacunacionDelPaciente(p1);
            var resultado2 = urgencias.VacunacionDelPaciente(p2);
            // Then
            Assert.Equal(PautaVacunacion.NoVacunado, resultado1);
            Assert.Equal(PautaVacunacion.NoVacunado, resultado2);
        }
        [Fact]
        public void VacunacionDelPaciente_Completa_Test()
        {
            // Given
            InfoVacPaciente p1 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.JandJ,
                DosisRecibidas = 1,
                FechaUltimaDosis = DateTime.Now.AddDays(-15),
                Edad = 28,
                Sexo = 'H'
            };
            GestorDeUrgencias urgencias = new GestorDeUrgencias(new Santitaria.Data.FakeRepository());
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
                FechaUltimaDosis = DateTime.Now.AddDays(-10),
                Edad = 28,
                Sexo = 'H'
            };
            InfoVacPaciente p2 = new InfoVacPaciente
            {
                TipoVacunacion = TipoVacuna.Astra,
                DosisRecibidas = 1,
                FechaUltimaDosis = DateTime.Now.AddDays(-16),
                Edad = 28,
                Sexo = 'H'
            };
            GestorDeUrgencias urgencias = new GestorDeUrgencias(new Santitaria.Data.FakeRepository());
            // When
            var resultado1 = urgencias.VacunacionDelPaciente(p1);
            var resultado2 = urgencias.VacunacionDelPaciente(p2);
            // Then
            Assert.Equal(PautaVacunacion.Incompleta, resultado1);
            Assert.Equal(PautaVacunacion.Incompleta, resultado2);
        }

        [Theory]
        [InlineData(true, true, true, true)]
        [InlineData(false, true, true, true)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]
        public void RealizacionDePCR_Test(bool sintomas, bool inmunodepresion, bool pautaCompleta, bool pcrEsperado)
        {
            //
            var urgencias = new GestorDeUrgencias(new Santitaria.Data.FakeRepository());
            //
            var resultado = urgencias.RealizacionDePCR(sintomas, inmunodepresion, pautaCompleta);
            //
            Assert.Equal(pcrEsperado, resultado);
        }
    }
}
