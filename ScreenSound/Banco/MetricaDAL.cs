using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class MetricaDAL
{
    private List<string> lista = new List<string>();
    
    public void ListarMetrica(string PeriodoGraduacao, string PeriodoPos)
    {
        using var conn = new Connection().ObterConexaoCorpore();
        conn.Open();

        lista.Add(PeriodoGraduacao);
        lista.Add(PeriodoPos);

        string sql = $"DECLARE @PERIODO_LETIVO_GRADUACAO VARCHAR(MAX) = {PeriodoGraduacao},\r\n        @PERIODO_LETIVO_POS       VARCHAR(MAX) = {PeriodoPos}\r\n\r\nselect\r\n     COUNT(*) qtd,\r\n     GFILIAL.NOME AS FILIAL,\r\n     STIPOCURSO.NOME AS [NIVEL DE ENSINO]\r\nFROM SMATRICPL\r\n     INNER JOIN GFILIAL\r\n             ON GFILIAL.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND GFILIAL.CODFILIAL   = SMATRICPL.CODFILIAL\r\n     INNER JOIN SHABILITACAOFILIAL\r\n                INNER JOIN STIPOCURSO\r\n                        ON STIPOCURSO.CODCOLIGADA = SHABILITACAOFILIAL.CODCOLIGADA\r\n                       AND STIPOCURSO.CODTIPOCURSO = SHABILITACAOFILIAL.CODTIPOCURSO\r\n             ON SHABILITACAOFILIAL.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND SHABILITACAOFILIAL.IDHABILITACAOFILIAL = SMATRICPL.IDHABILITACAOFILIAL\r\n     INNER JOIN SSTATUS\r\n             ON SSTATUS.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND SSTATUS.CODSTATUS   = SMATRICPL.CODSTATUS\r\n     INNER JOIN SPLETIVO\r\n             ON SPLETIVO.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND SPLETIVO.IDPERLET = SMATRICPL.IDPERLET\r\nWHERE \r\n     SMATRICPL.CODCOLIGADA = 1\r\n AND SPLETIVO.CODPERLET = @PERIODO_LETIVO_GRADUACAO\r\n AND SSTATUS.DESCRICAO IN ('CURSADO', 'MATRICULADO')\r\n AND SHABILITACAOFILIAL.CODTIPOCURSO <> 2\r\nGROUP BY \r\n      GFILIAL.NOME,\r\n      STIPOCURSO.NOME\r\n\r\n------------------------------------------------------------------------------------------------------\r\nUNION\r\n------------------------------------------------------------------------------------------------------\r\n\r\nselect\r\n     COUNT(*) qtd,\r\n     GFILIAL.NOME AS FILIAL,\r\n     STIPOCURSO.NOME AS [NIVEL DE ENSINO]\r\nFROM SMATRICPL\r\n     INNER JOIN GFILIAL\r\n             ON GFILIAL.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND GFILIAL.CODFILIAL   = SMATRICPL.CODFILIAL\r\n     INNER JOIN SHABILITACAOFILIAL\r\n                INNER JOIN STIPOCURSO\r\n                        ON STIPOCURSO.CODCOLIGADA = SHABILITACAOFILIAL.CODCOLIGADA\r\n                       AND STIPOCURSO.CODTIPOCURSO = SHABILITACAOFILIAL.CODTIPOCURSO\r\n             ON SHABILITACAOFILIAL.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND SHABILITACAOFILIAL.IDHABILITACAOFILIAL = SMATRICPL.IDHABILITACAOFILIAL\r\n     INNER JOIN SSTATUS\r\n             ON SSTATUS.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND SSTATUS.CODSTATUS   = SMATRICPL.CODSTATUS\r\n     INNER JOIN SPLETIVO\r\n             ON SPLETIVO.CODCOLIGADA = SMATRICPL.CODCOLIGADA\r\n            AND SPLETIVO.IDPERLET = SMATRICPL.IDPERLET\r\nWHERE \r\n     SMATRICPL.CODCOLIGADA = 1\r\n AND SPLETIVO.CODPERLET = @PERIODO_LETIVO_POS\r\n AND SSTATUS.DESCRICAO IN ('CURSADO', 'MATRICULADO')\r\n AND SHABILITACAOFILIAL.CODTIPOCURSO = 2\r\nGROUP BY \r\n      GFILIAL.NOME,\r\n      STIPOCURSO.NOME\r\n\r\nORDER BY 3, 2";
        foreach (var item in lista)
        {
            Console.WriteLine($"{item}");
        }
        //return lista;
    }
}
