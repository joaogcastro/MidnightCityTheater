using MidnightCityTheater.Models; 

namespace MidnightCityTheater.Utils
{
    public static class VendaUtils
    {
        private const decimal ComissaoFuncionario = 2.0m;
        /*

        public static decimal CalcularPrecoTotal(Ingresso ingresso)
        {
            if (ingresso == null)
            {
                throw new ArgumentNullException(nameof(ingresso), "O ingresso não pode ser nulo.");
            }

            decimal precoTotal = 0;

            // Verifique se o ingresso tem um preço definido
            if (decimal.TryParse(ingresso.Preco, out decimal precoFilme))
            {
                precoTotal += precoFilme;
            }

            // Verifique se o ingresso tem uma venda associada
            if (ingresso.Venda != null)
            {
                // Verifique se a venda possui snacks associados
                if (ingresso.Venda.Snacks != null)
                {
                    // Calcule o preço dos snacks
                    foreach (var snack in ingresso.Venda.Snacks)
                    {
                        // Verifique se o snack é do tipo Snack (evita exceções de tipo)
                        if (snack is Snack snackObj)
                        {
                            if (snackObj.Pipoca != null)
                            {
                                // Adicione o preço da pipoca
                                precoTotal += CalcularPrecoSnack(snackObj.Pipoca);
                            }
                            if (snackObj.Bebida != null)
                            {
                                // Adicione o preço da bebida
                                precoTotal += CalcularPrecoSnack(snackObj.Bebida);
                            }
                            if (snackObj.Doce != null)
                            {
                                // Adicione o preço do doce
                                precoTotal += CalcularPrecoSnack(snackObj.Doce);
                            }
                        }
                    }
                }
            }

            // Adicione a comissão do funcionário
            precoTotal += ComissaoFuncionario;

            return precoTotal;
        }

        private static decimal CalcularPrecoSnack(List<Pipoca> pipoca)
        {
            throw new NotImplementedException();
        }

        private static decimal CalcularPrecoSnack(List<Bebida> bebida)
        {
            throw new NotImplementedException();
        }

        private static decimal CalcularPrecoSnack(List<Doce> doce)
        {
            throw new NotImplementedException();
        }

        private static decimal CalcularPrecoSnack(List<Snack> snacks)
        {
            decimal precoTotalSnack = 0;

            foreach (var snack in snacks)
            {
                // Adicione o preço do snack ao preço total
                precoTotalSnack += snack.Preco;
            }

            return precoTotalSnack;
        }
        */
    }
}
