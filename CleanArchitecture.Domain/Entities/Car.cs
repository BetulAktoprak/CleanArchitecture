using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities;
public sealed class Car : Entity
{
    public string Name { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int EnginePower { get; set; }
}
