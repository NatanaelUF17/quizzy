using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

sealed class UserProfile
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    [ForeignKey("SupabaseAuthUser")]
    public Guid SupabaseUserId { get; set; }
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    public string? AvatarUrl { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}