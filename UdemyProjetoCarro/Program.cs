using System.Runtime.InteropServices;
Console.WriteLine($"{Cores.Branco} - {(int)Cores.Branco}");
Console.WriteLine($"{Cores.Vermelho} - {(int)Cores.Vermelho}");
Console.WriteLine($"{Cores.Preto} - {(int)Cores.Preto}");
Console.WriteLine($"{Cores.Cinza} - {(int)Cores.Cinza}");
Console.WriteLine($"{Cores.Azul} - {(int)Cores.Azul}");
Console.WriteLine("Selecione a cor do carro");
int cor = Convert.ToInt32(Console.ReadLine());
Carro chevrolet = new("sedan", "onix", "chevrolet", 1999, 100, cor);
Console.WriteLine($"{chevrolet.Modelo}, {chevrolet.Marca}, {chevrolet.Montadora}, {chevrolet.Ano}, {chevrolet.Potencia}");
//chamando o metodo de velocidade maxima
double velocidadeMaxima = chevrolet.VelocidadeMaxima(chevrolet.Potencia);
Console.WriteLine($"Velocidade maxima(potencia x 1.75): {velocidadeMaxima}");
//chamando o metodo de aumentar potencia em 3
double aumentarPotencia = chevrolet.AumentarPotencia(chevrolet.Potencia);
Console.WriteLine(aumentarPotencia);
Console.WriteLine(chevrolet.Potencia);
//chamando metodo para aumentar a potencia em referencia(trocando o valor da variavel na memoria)
double aumentarPotencia2 = chevrolet.AumentarPotencia(ref chevrolet.Potencia);
Console.WriteLine(aumentarPotencia2);
Console.WriteLine($"valor por referencia = {chevrolet.Potencia}");
//chamando o metodo aumentar potencia e velocidade utilizando out em uma variavel nao declarada
double aumentarPotenciaVelocidade = chevrolet.AumentarPotenciaVelocidade(chevrolet.Potencia, out double velocidade);
Console.WriteLine($"Valor da nova potencia: {aumentarPotenciaVelocidade}, valor da velocidade: {velocidade}");
//Chamando o metodo ExibirInfo utilizando um parametro opcional
chevrolet.ExibirInfo(chevrolet.Modelo, chevrolet.Marca, chevrolet.Montadora, chevrolet.Potencia);
//chamando o metodo estático sem fazer uma instancia da classe(objeto)
//Console.WriteLine(Carro.ObterValorIpva());
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
    public int Cor;
    public Carro(string modelo, string marca, string montadora, int ano, int potencia, int cor)
    {
        Modelo = modelo;
        Marca = marca;
        Montadora = montadora;
        Ano = ano;
        Potencia = potencia;
        Cor = cor;
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
    public void ExibirInfo(string? modelo, string? marca, string? montadora, int potencia, int Cor = 1, int ano = 2010)
    {
        Console.WriteLine($"{modelo}, {marca}, {montadora}, {ano}, {potencia}, {((Cores)Cor)}");
    }
    static Carro()
    {
        ValorIpva = 4;
    }
}
