namespace LearnCraft.Domain;

public class Cachorro : BaseEntity<int>
{
    public DateTime Nascimento { get; set; }
    public bool Adotado { get; set; }
    public Pelagem Pelagem { get; set; }
    public float Peso { get; set; }

}

[Flags]
public enum Pelagem
{
    None,
    Curto,
    Medio,
    Longo
}