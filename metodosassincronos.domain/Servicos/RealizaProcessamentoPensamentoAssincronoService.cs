namespace metodosassincronos.domain.Servicos
{
    public class RealizaProcessamentoPensamentoAssincronoService
    {
        public async Task Processar()
        {
            var liberadoEmissao = VerificaLiberacaoEmissaoAsync();
            var estabilidadeSefaz = VerificaEstabilidadeSefazAsync();
            var consutaFaturas = ConsultaListaFaturasAsync();

            if (await liberadoEmissao)
            {
                if (await estabilidadeSefaz)
                {
                    var faturas = await consutaFaturas;

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
            var envios = new List<Task>();

            var semaphoreSlim = new SemaphoreSlim(2);

            foreach (var fat in faturas)
            {
                await semaphoreSlim.WaitAsync();

                var tarefa = EnviaFaturaAsync(fat, semaphoreSlim);

                envios.Add(tarefa);
            }

            await Task.WhenAll(envios);
        }

        private async Task EnviaFaturaAsync(string fatura, SemaphoreSlim semaphore)
        {
            await Task.Delay(1000);

            semaphore.Release();
        }
    }
}
