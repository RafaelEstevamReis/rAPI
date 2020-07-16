using System;
using System.Collections.Generic;
using System.Text;

namespace Net.RafaelEstevam.rAPI
{
    public class EmpresaCNPJ
    {
        public EmpresaCNPJ() { }
        public enum eSituacaoCadastral
        {
            Nula = 01,
            Ativa = 02,
            Suspensa = 03,
            Inapta = 04,
            Baixada = 06,

            UNKOWN = 08,
        }

        public int TipoRegistro { get; set; }
        public string IndicadorFull { get; set; }
        public string TipoAtualizacao { get; set; }
        public string CNPJ { get; set; }
        public int TipoEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public eSituacaoCadastral SituacaoCadastral { get; set; }
        public DateTime DataSituacaoCadastral { get; set; }
        public int MotivoSituacaoCadastral { get; set; }
        public string NM_PaisExterior { get; set; }
        public string CO_Pais { get; set; }
        public string NM_Pais { get; set; }
        public int CodigoNaturezaJuridica { get; set; }
        public DateTime DataInicioAtividade { get; set; }
        public int CNAE_Fiscal { get; set; }
        public string DescricaoTipoLogradouro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public int CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string TelefoneFax { get; set; }
        public string CorreioEletronico { get; set; }
        public int QualificacaoResponsavel { get; set; }
        public decimal CapitalSocialEmpresa { get; set; }
        public string PorteEmpresa { get; set; }
        public string OpcaoSimples { get; set; }
        public DateTime DataOpcaoSimples { get; set; }
        public DateTime DataExclusaoSimples { get; set; }
        public string OpcaoMEI { get; set; }
        public string SituacaoEspecial { get; set; }
        public DateTime DataSituacaoEspecial { get; set; }
    }
}
