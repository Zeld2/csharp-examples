using System;

namespace Rev
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = Menu();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Name = Console.ReadLine();

                        Console.WriteLine("Informe o nome do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (a.Name != null)
                            {
                                Console.WriteLine($"Aluno: {a.Name}, Nota: {a.Nota}");
                            }
                        }
                        break;

                    case "3":

                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        foreach (var a in alunos)
                        {
                            if (a.Name != null)
                            {
                                nrAlunos++;
                                notaTotal = notaTotal + a.Nota;
                            }
                        }
                        var media = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (media < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (media < 4)
                        {
                            conceitoGeral = Conceito.D;

                        }
                        else if (media < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (media < 6)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"Média dos alunos: {media}");
                        Console.WriteLine($"Conceito: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = Menu();
            }
        }

        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
