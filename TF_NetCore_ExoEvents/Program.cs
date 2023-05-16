namespace TF_NetCore_ExoEvents
{
    internal class Program
    {
        static ConsoleColor DEFAULT_COLOR;

        static void Main(string[] args)
        {
            DEFAULT_COLOR = Console.ForegroundColor;
            IEnumerable<Etudiant> etudiants = new List<Etudiant>()
            {
                new Etudiant(1, "Doe", "John"),
                new Etudiant(2, "Doe", "Jane"),
                new Etudiant(3, "Smith", "Hannibal"),
            };

            AfficheEtudiants(etudiants);

            foreach (Etudiant etudiant in etudiants)
            {
                etudiant.OnStatutChanged += OnStatutChanged;
            }

            bool exit = false;

            while (!exit)
            {
                string texte;
                int id = 0;
                do
                {
                    Console.Write("Entrez l'id de l'étudiant ou 'Q' pour quitter : ");
                    texte = Console.ReadLine()!;
                } while (texte.ToUpper() != "Q" && !int.TryParse(texte, out id));

                if (texte.ToUpper() is "Q")
                {
                    exit = true;
                }
                else
                {
                    Etudiant? etudiant = null;
                    foreach (Etudiant e in etudiants)
                    {
                        if (e.Id == id)
                        {
                            etudiant = e;
                        }
                    }

                    if(etudiant is not null)
                    {
                        etudiant.Statut = (etudiant.Statut == Statut.Present) ? Statut.Absent : Statut.Present;
                    }
                }
            }
            
        }

        private static void OnStatutChanged(Etudiant etudiant)
        {
            Console.SetCursorPosition(30, etudiant.Id);
            Console.ForegroundColor = GetForeGroundColor(etudiant.Statut);
            DisplayEtudiant(etudiant);
            Console.ForegroundColor = DEFAULT_COLOR;
            Console.SetCursorPosition(0, 10);
            Console.Write(new string(' ', 60));
            Console.SetCursorPosition(0, 10);
        }

        private static ConsoleColor GetForeGroundColor(Statut statut)
        {
            return (statut == Statut.Present) ? ConsoleColor.Green : ConsoleColor.Red;
        }

        private static void DisplayEtudiant(Etudiant etudiant)
        {
            Console.WriteLine($"({etudiant.Id}) {etudiant.Nom} {etudiant.Prenom}");
        }

        static void AfficheEtudiants(IEnumerable<Etudiant> source)
        {
            foreach (Etudiant e in source)
            {
                Console.SetCursorPosition(30, e.Id);
                Console.ForegroundColor = GetForeGroundColor(e.Statut);
                DisplayEtudiant(e);
            }
            Console.ForegroundColor = DEFAULT_COLOR;
            Console.SetCursorPosition(0, 10);
        }
    }
}