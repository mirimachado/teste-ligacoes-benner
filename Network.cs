namespace TaskBennerSistemas;

public class Network  
{
    private int Number { get; set; }
    private List<int> _values = [];
    private List<int[]> _directConnections = []; 
    private List<List<int>> _indirectConnections = [];  
    
    public Network(int number) 
    {
        if (Decimal.IsNegative(number)) 
        { 
            throw new Exception("O número precisa ser positivo!");
        }
        if (number == 0) 
        {
            Console.WriteLine("O número precisa ser maior do que zero!");
        } 
        if (Decimal.IsInteger(number)) 
        {
            Console.WriteLine("O número é inteiro e positivo, correto.");
        }
   
        Number = number;
        for (int i = 1; i <= number; i++) 
        {
            _values.Add(i);
        } 
    }

    public List<int[]> DirectConnections 
    {
        get => _directConnections;
        set => _directConnections = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public void Connect(int numberOne, int numberTwo)
    {
        if (_values.Contains(numberOne) && _values.Contains(numberTwo)) 
        {
            int[] vect = new int[2];
            vect[0] = numberOne;
            vect[1] = numberTwo;
            _directConnections.Add(vect);
            
            for (int i = 0; i < _directConnections.Count; i++)
            {
                int[] x = _directConnections[i];
                foreach (var v in _directConnections) 
                {
                    if (v != x) 
                    {
                        if (v[0] == x[0] || v[0] == x[1] || v[1] == x[0] || v[1] == x[1]) 
                        {
                            List<int> connections = [];
                            connections.Add(v[0]);
                            connections.Add(v[1]);
                            connections.Add(x[0]);
                            connections.Add(x[1]);
                            _indirectConnections.Add(connections);
                        }
                    }
                }
            }
        }
         
        if (numberOne == numberTwo) 
        {
            throw new Exception("Os números não podem ser iguais, digite dois números diferentes para realizar uma conexão.");
        }
        if (!_values.Contains(numberOne) && !_values.Contains(numberTwo)) 
        {
            throw new Exception("Os dois números informados precisam existir no conjunto. Tente novamente com números válidos.");
        }
    } 
    
    public bool Query(int numberOne, int numberTwo) 
    {
        if (_values.Contains(numberOne) && _values.Contains(numberTwo)) 
        {
            foreach (var vector in _directConnections) 
            {
                if (vector.Contains(numberOne) && vector.Contains(numberTwo)) 
                {
                    return true;
                } 
            }

            for (int i = 0; i < _indirectConnections.Count; i++) 
            {
                List<int> x = _indirectConnections[i];
                foreach (var list in _indirectConnections) 
                {
                    if (list != x)
                    {
                        for (int j = 0; j < _indirectConnections[j].Count; j++) 
                        {   
                            if (list.Contains(x[j]))
                            {
                                List<int> newConnections = [];
                                newConnections.AddRange(list);
                                newConnections.Add(x[j]);
                                if (newConnections.Contains(numberOne) && newConnections.Contains(numberTwo)) 
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        if (!_values.Contains(numberOne) && !_values.Contains(numberTwo)) 
        {
            throw new Exception("Os dois números informados precisam existir no conjunto. Tente novamente com números válidos.");
        }
        if (numberOne == numberTwo) 
        {
            throw new Exception("Os números não podem ser iguais, digite dois números diferentes para verificar se há conexão.");
        }
        return false;
    }
}