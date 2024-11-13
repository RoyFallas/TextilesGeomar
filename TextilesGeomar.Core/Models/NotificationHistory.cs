using System;
using System.Collections.Generic;

namespace TextilesGeomar.Core.Models;

public partial class NotificationHistory
{
    public int NotificationId { get; set; }

    public string EntityType { get; set; } = null!;

    public int EntityId { get; set; }

    public string NotificationType { get; set; } = null!;

    public DateTime SentDate { get; set; }

    public string? RecipientEmail { get; set; }

    public string? SentStatus { get; set; }
}
