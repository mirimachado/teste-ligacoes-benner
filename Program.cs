using TaskBennerSistemas;

Console.WriteLine("Bem-vindo (a) ao Programa de Conexões: ");
Console.WriteLine("Digite um número para o tamanho do conjunto: ");
int numberSize = int.Parse(Console.ReadLine());
Network network = new Network(numberSize); 

bool runProgramA = true;
bool runProgramB = true;

while (runProgramA) {
    Console.WriteLine("Digite dois números para realizar uma conexão. ");
    Console.WriteLine("Primeiro número: ");
    int firstNumber = int.Parse(Console.ReadLine());
    Console.WriteLine("Segundo número: ");
    int secondNumber = int.Parse(Console.ReadLine());
    network.Connect(firstNumber, secondNumber);
    Console.WriteLine("Deseja realizar mais conexões? Digite F para finalizar as conexões ou C para continuar realizando conexões: ");
    string option = Console.ReadLine();
  
    if (option == "F") {
        runProgramA = false;
        while (runProgramB) {
            Console.WriteLine("Por favor, agora digite dois números para verificar se há uma conexão direta ou indireta entre eles: ");
            Console.WriteLine("Primeiro número: ");
            int firstNumberVerification = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Segundo número: ");
         
            int secondNumberVerification = int.Parse(Console.ReadLine());
            bool result = network.Query(firstNumberVerification, secondNumberVerification);
            Console.WriteLine("Resultado da verificação entre os números (True: há conexão direta ou indireta - False: não há conexão.): " + result);
            Console.WriteLine("Deseja continuar realizando verificações de conexões? Digite C para continuar ou F para finalizar o programa.");
            string optionB = Console.ReadLine();

            if (optionB == "F") {
                runProgramB = false;
                Console.WriteLine("Obrigada, até breve. Encerrando o programa... ");
            }

        }
    }
}