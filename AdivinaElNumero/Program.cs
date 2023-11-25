using System.ComponentModel.Design;

Console.WriteLine("Juego de Adivinar un Numero del 1 al 10");
Console.WriteLine("");


Random numero = new Random();
int numeroAleatorio = numero.Next(1, 10);
int intentos = 0;

StartGame();

void StartGame()
{

    Console.WriteLine("Como es tu nombre?");
    var jugador = Console.ReadLine();
    WantToPlay(jugador);
  
}

void WantToPlay(string? jugador)
{
    Console.WriteLine($"Hola {jugador} listo para jugar?  (Si/No)");
    var play = Console.ReadLine();

    switch (play?.ToLower().Trim())
    {

        case "si":
            Play();
            break;
            
        case "no":
            DontPlay();
            break;
        default:
            Console.WriteLine("No es una opcion valida");
            WantToPlay(jugador);
            break;
    }

}

void Play()
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
            Play();
        }
        else if (numeroUsuario > numeroAleatorio)
        {
            Console.WriteLine($"El numero debe ser menor");
            intentos++;
            Play();
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Sucedio un error : {e.Message}");
        Play();
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
        Play();
    }
    else
    {
        DontPlay();
    }
}