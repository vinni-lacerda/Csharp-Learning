using System.Runtime.InteropServices;

Carro chevrolet = new("sedan", "onix", "chevrolet", 1999, 100);
System.Console.WriteLine($"{chevrolet.Modelo}, {chevrolet.Marca}, {chevrolet.Montadora}, {chevrolet.Ano}, {chevrolet.Potencia}");
//chamando o metodo de velocidade maxima
double velocidadeMaxima = chevrolet.VelocidadeMaxima(chevrolet.Potencia);
System.Console.WriteLine($"Velocidade maxima(potencia x 1.75): {velocidadeMaxima}");
//chamando o metodo de aumentar potencia em 3
double aumentarPotencia = chevrolet.AumentarPotencia(chevrolet.Potencia);
System.Console.WriteLine(aumentarPotencia);
System.Console.WriteLine(chevrolet.Potencia);
//chamando metodo para aumentar a potencia em referencia(trocando o valor da variavel na memoria)
double aumentarPotencia2 = chevrolet.AumentarPotencia(ref chevrolet.Potencia);
System.Console.WriteLine(aumentarPotencia2);
System.Console.WriteLine($"valor por referencia = {chevrolet.Potencia}");
//chamando o metodo aumentar potencia e velocidade utilizando out em uma variavel nao declarada
double aumentarPotenciaVelocidade = chevrolet.AumentarPotenciaVelocidade(chevrolet.Potencia, out double velocidade);
System.Console.WriteLine($"Valor da nova potencia: {aumentarPotenciaVelocidade}, valor da velocidade: {velocidade}");
//Chamando o metodo ExibirInfo utilizando um parametro opcional
chevrolet.ExibirInfo(chevrolet.Modelo, chevrolet.Marca, chevrolet.Montadora, chevrolet.Potencia);
//chamando o metodo estático sem fazer uma instancia da classe(objeto)
System.Console.WriteLine(Carro.ObterValorIpva());
public class Carro
{
    public string? Modelo;
    public string? Marca;
    public string? Montadora;
    private int ano;
    public int Ano
    {
        get { return ano; }
        set
        {
            if (value < 2000) { ano = 2000; }
            else if (value > 2022) { ano = 2022; }
            else { ano = value; }
        }
    }
    public int Potencia;
    public static double ValorIpva;
    public Carro(string modelo, string marca, string montadora, int ano, int potencia)
    {
        Modelo = modelo;
        Marca = marca;
        Montadora = montadora;
        Ano = ano;
        Potencia = potencia;
    }
    public Carro(string modelo, string marca)
    {
        Modelo = modelo;
        Marca = marca;
    }
    public double VelocidadeMaxima(int potencia)
    {
        return potencia * 1.75;
    }
    public int AumentarPotencia(int potencia)
    {
        return potencia += 3;
    }
    //criando sobrecarga de metodo em aumentar potencia para utilizar o ref
    public int AumentarPotencia(ref int potencia)
    {
        return potencia += 5;
    }
    public double AumentarPotenciaVelocidade(int potencia, out double velocidade)
    {
        potencia += 7;
        velocidade = potencia * 1.75;
        return potencia;
    }
    public void ExibirInfo(string? modelo, string? marca, string? montadora, int potencia, int ano = 2010)
    {
        System.Console.WriteLine($"{modelo}, {marca}, {montadora}, {ano}, {potencia}");
    }
    public static double ObterValorIpva()
    {
        return ValorIpva + 4;
    }
}
