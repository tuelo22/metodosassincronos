namespace metodosassincronos.domain.Servicos
{
    public class RealizaProcessamentoPensamentoProceduralService
    {
        public async Task Processar()
        {
            if (await VerificaLiberacaoEmissaoAsync())
            {
                if (await VerificaEstabilidadeSefazAsync())
                {
                    var faturas = await ConsultaListaFaturasAsync();

                    await EnviaFaturasAsync(faturas);
                }
            }
        }

        private async Task<List<String>> ConsultaListaFaturasAsync()
        {
            await Task.Delay(5000);

            return ["Fatura 1", "Fatura 2", "Fatura 3"];
        }

        private async Task<Boolean> VerificaEstabilidadeSefazAsync()
        {
            await Task.Delay(5000);

            return true;
        }

        private async Task<Boolean> VerificaLiberacaoEmissaoAsync()
        {
            await Task.Delay(5000);

            return true;
        }

        private async Task EnviaFaturasAsync(List<String> faturas)
        {
            foreach (var fat in faturas) 
            {
                await Task.Delay(5000);
            }
        }
    }
}
