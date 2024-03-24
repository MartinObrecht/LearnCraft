namespace LearnCraft.Domain;

public class Cachorro : BaseEntity<int>
{
    public DateTime Nascimento { get; set; }
    public bool Adotado { get; set; }
    public TiposPelagem Pelagem { get; set; }
    public float Peso { get; set; }

}

public enum TiposPelagem
{
    none,
    curto,
    medio,
    longo
}