using System;
using System.Collections.Generic;

namespace TpCsharpPoKEKW.Model;

public partial class Etudiant
{
    public int EtudiantId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateOnly DateNaissance { get; set; }

    public string Email { get; set; } = null!;

    public int ClasseId { get; set; }

    public virtual Class Classe { get; set; } = null!;

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
