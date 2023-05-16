using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TF_NetCore_ExoEvents
{
    internal class Etudiant
    {
        public event StatutHandler? OnStatutChanged;

        private Statut _statut;
        public int Id { get; init; }
        public string Nom { get; init; }
        public string Prenom { get; init; }

        public Statut Statut
        {
            get
            {
                return _statut;
            }

            set
            {
                if (_statut != value)
                {
                    _statut = value;
                    OnStatutChanged?.Invoke(this);
                }
            }
        }

        public Etudiant(int id, string nom, string prenom)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
        }
    }
}
