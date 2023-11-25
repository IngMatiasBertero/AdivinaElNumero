using System.ComponentModel.Design;

Console.WriteLine("Juego de Adivinar un Numero del 1 al 10");
Console.WriteLine("");


Random numero = new Random();

int intentos = 0;

StartGame();

void StartGame()
{

    Console.WriteLine("Como es tu nombre?");
    var jugador = Console.ReadLine();
    int numeroAleatorio = numero.Next(1, 10);
    WantToPlay(jugador,numeroAleatorio);
  
}

void WantToPlay(string? jugador, int numeroAleatorio)
{
    Console.WriteLine($"Hola {jugador} listo para jugar?  (Si/No)");
    var play = Console.ReadLine();

    switch (play?.ToLower().Trim())
    {

        case "si":
            Play(numeroAleatorio);
            break;
            
        case "no":
            DontPlay();
            break;
        default:
            Console.WriteLine("No es una opcion valida");
            WantToPlay(jugador, numeroAleatorio);
            break;
    }

}

void Play(int numeroAleatorio)
{
    try
    {
        Console.WriteLine("Introduzca un numero del 1 al 10");
        int numeroUsuario = Convert.ToInt16(Console.ReadLine());

        if (numeroUsuario == null)
            throw new Exception("Necesitas elegir un valor");
        
        if(numeroUsuario < 1 || numeroUsuario > 10)
            throw new Exception("Por favor elegir un numero del 1 al 10");


        if (numeroUsuario == numeroAleatorio)
        {
            Console.WriteLine("Adivinasteeee!!!!");
            Console.WriteLine($"Tus intentos fueron: {intentos}");
            intentos = 0;
            Seguir();
            
        }
        else if (numeroUsuario < numeroAleatorio)
        {
            Console.WriteLine($"El numero debe ser mayor");
            intentos++;
            Play(numeroAleatorio);
        }
        else if (numeroUsuario > numeroAleatorio)
        {
            Console.WriteLine($"El numero debe ser menor");
            intentos++;
            Play(numeroAleatorio);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Sucedio un error : {e.Message}");
        Play(numeroAleatorio);
    }

    


}

void DontPlay()
{
    Console.WriteLine("Gracias por jugar");
}
void Seguir()
{
    Console.WriteLine("Quieres Seguir jugando? Si/No");
    var seguir = Console.ReadLine();
    if (seguir?.ToLower() == "si")
    {
        int numeroAleatorio = numero.Next(1, 10);
        Play(numeroAleatorio);
    }
    else
    {
        DontPlay();
    }
}