internal record Ticket
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }

    public override string ToString()
    {
        return $"Title: {Title}, Description: {Description}, Email: {Email}, Phone: {Phone}";
    }
}