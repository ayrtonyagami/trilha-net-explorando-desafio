
namespace DesafioProjetoHospedagem.Models
{
    public class Hotel
    {
        public Hotel(string nome)
        {
            this.Nome = nome;
        }
        private string Nome {get; set; }
        public List<Reserva> Reservas { get; set; }

        public void CadastrarReserva()
        {
            if(Reservas == null) Reservas = new List<Reserva>();
            List<Pessoa> hospedes = new List<Pessoa>();

            string exibirMenu = "s";
            int numuroHospede = 0;
            while (exibirMenu.ToLower() == "s")
            {
                numuroHospede ++;
                Pessoa p1 = new Pessoa();
                Console.Write($"Digita o Nome da {numuroHospede}º pessoa: ");
                p1.Nome = Console.ReadLine();
                hospedes.Add(p1);

                Console.Write("Deseja adicionar mais um hospedi? (s/n)");
                exibirMenu = Console.ReadLine();
            }

            Suite suite = new Suite();
            Console.Write("Digita o Tipo de Suite: ");
            suite.TipoSuite = Console.ReadLine();
            
            Console.Write("Digita a capacidade da Suite: ");
            suite.Capacidade = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Digita a valor diario da Suite: ");
            suite.ValorDiaria = Convert.ToDecimal(Console.ReadLine());
            
            Console.Write("Digita o número de dias: ");
            int dias = Convert.ToInt32(Console.ReadLine());
            Reserva reserva = new Reserva(dias);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

            Reservas.Add(reserva);
        }
        public void TotalReservas()
        {
            int numReserva = 0;

            if(Reservas != null) 
                numReserva = Reservas.Count;

            Console.WriteLine("Total de reservas: {0}", numReserva);
        }

        public void TotalValor()
        {
            decimal valorTotal = 0;

            if(Reservas != null) 
                valorTotal = Reservas.Sum(x=> x.CalcularValorDiaria());

            Console.WriteLine("Total de Valor {0}", valorTotal);
        }
    }
}