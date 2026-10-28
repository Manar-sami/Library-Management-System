


public class ResearchPaper : LibraryItem
{
    public string Researcher { get; set; }
    public string ResearchField { get; set; }

    public ResearchPaper(int id, string title, bool isAvailable, bool isActive,
                         string researcher, string researchField)
        : base(id, title, isAvailable, isActive)
    {
        Researcher = researcher;
        ResearchField = researchField;
    }

    public override decimal CalculateLateFee()
{
    return 2m;
}

public override int GetLoanPeriod()
{
    return 7;
}

public override string ToString()
    {
        return $"ID:{Id} ---- Title:{Title} ---- IsAvailable:{IsAvailable} ----- IsActive:{IsActive} ---- Researcher:{Researcher} ---- ResearchField:{ResearchField}";
    }
}
