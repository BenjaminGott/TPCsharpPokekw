using System;
using System.Collections.Generic;

namespace TpCsharpPoKEKW.Model;

public partial class Inscription
{
    public int InscriptionId { get; set; }

    public int EtudiantId { get; set; }

    public int CoursId { get; set; }

    public DateOnly? DateInscription { get; set; }

    public virtual Cour Cours { get; set; } = null!;

    public virtual Etudiant Etudiant { get; set; } = null!;
}
