namespace TaskBennerSistemas;

public class Network  
{

    private int number { get; set; }
    private List<int> values = new List<int>();
    public List<int[]> directConnections = new List<int[]>() ; 
    private List<List<int>> indirectConnections = new List<List<int>>(); 
    
    
    public Network(int number) {
        if (Decimal.IsNegative(number)) { 
            throw new Exception("O número precisa ser positivo!");
        }
        if (number == 0) {
            Console.WriteLine("O número precisa ser maior do que zero!");
        } 
        if (Decimal.IsInteger(number)) {
            Console.WriteLine("O número é inteiro e positivo, correto.");
        }
        this.number = number;
        for (int i = 1; i <= number; i++) {
            values.Add(i);
        } 
    }

    public List<int[]> DirectConnections 
    {
        get => directConnections;
        set => directConnections = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public void Connect(int numberOne, int numberTwo) {
        if (values.Contains(numberOne) && values.Contains(numberTwo)) {
            int[] vect = new int[2];
            vect[0] = numberOne;
            vect[1] = numberTwo;
            directConnections.Add(vect);
            
            for (int i = 0; i < directConnections.Count; i++) {
                
                int[] x = directConnections[i];
                foreach (var v in directConnections) {
                    if (v != x) {
                        if (v[0] == x[0] || v[0] == x[1] || v[1] == x[0] || v[1] == x[1]) {
                            
                            List<int> connections = new List<int>();
                            
                            connections.Add(v[0]);
                            connections.Add(v[1]);
                            connections.Add(x[0]);
                            connections.Add(x[1]);
                            indirectConnections.Add(connections);
                            
                        }
                    }
                }
            }
        }
         
        if (numberOne == numberTwo) {
            throw new Exception("Os números não podem ser iguais, digite dois números diferentes para realizar uma conexão.");
        }
        if (!values.Contains(numberOne) && !values.Contains(numberTwo)) {
            throw new Exception("Os dois números informados precisam existir no conjunto. Tente novamente com números válidos.");
        }
    } 
    
    public Boolean Query(int numberOne, int numberTwo) {
        if (values.Contains(numberOne) && values.Contains(numberTwo)) {
            
            foreach (var vector in directConnections) {
                if (vector.Contains(numberOne) && vector.Contains(numberTwo)) {
                    return true;
                }
            }

            for (int i = 0; i < indirectConnections.Count; i++) {
                
                List<int> x = indirectConnections[i];
                foreach (var list in indirectConnections) {
                    if (list != x) {
                        
                        for (int j = 0; j < indirectConnections[j].Count; j++) {   
                            if (list.Contains(x[j])) {
                                List<int> newConnections = new List<int>();
                                newConnections.AddRange(list);
                                newConnections.Add(x[j]);

                                if (newConnections.Contains(numberOne) && newConnections.Contains(numberTwo)) {
                                    return true;
                                }
                                
                            }
                            
                        }
                    
                    }
                    
                }
            }
        }
        
        
        if (!values.Contains(numberOne) && !values.Contains(numberTwo)) {
            throw new Exception("Os dois números informados precisam existir no conjunto. Tente novamente com números válidos.");
        }
        if (numberOne == numberTwo) {
            throw new Exception("Os números não podem ser iguais, digite dois números diferentes para verificar se há conexão.");
        }
        return false;
    }
    
}