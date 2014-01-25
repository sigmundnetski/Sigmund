using System;

public class BnetInvitation
{
    private ulong m_creationTimeMicrosec;
    private ulong m_expirationTimeMicrosec;
    private BnetInvitationId m_id;
    private BnetAccountId m_inviteeId;
    private string m_inviteeName;
    private BnetAccountId m_inviterId;
    private string m_inviterName;
    private string m_message;

    public static BnetInvitation CreateFromDll(BattleNet.DllFriendsUpdate src)
    {
        return new BnetInvitation { m_id = new BnetInvitationId(src.long1), m_inviterId = BnetAccountId.CreateFromDll(src.entity1), m_inviteeId = BnetAccountId.CreateFromDll(src.entity2), m_inviterName = DLLUtils.StringFromNativeUtf8(src.string1), m_inviteeName = DLLUtils.StringFromNativeUtf8(src.string2), m_message = DLLUtils.StringFromNativeUtf8(src.string3), m_creationTimeMicrosec = src.long2, m_expirationTimeMicrosec = src.long3 };
    }

    public bool Equals(BnetInvitationId other)
    {
        if (other == null)
        {
            return false;
        }
        return this.m_id.Equals(other);
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        BnetInvitation invitation = obj as BnetInvitation;
        if (invitation == null)
        {
            return false;
        }
        return this.m_id.Equals(invitation.m_id);
    }

    public ulong GetCreationTimeMicrosec()
    {
        return this.m_creationTimeMicrosec;
    }

    public ulong GetExpirationTimeMicrosec()
    {
        return this.m_expirationTimeMicrosec;
    }

    public override int GetHashCode()
    {
        return this.m_id.GetHashCode();
    }

    public BnetInvitationId GetId()
    {
        return this.m_id;
    }

    public BnetAccountId GetInviteeId()
    {
        return this.m_inviteeId;
    }

    public string GetInviteeName()
    {
        return this.m_inviteeName;
    }

    public BnetAccountId GetInviterId()
    {
        return this.m_inviterId;
    }

    public string GetInviterName()
    {
        return this.m_inviterName;
    }

    public string GetMessage()
    {
        return this.m_message;
    }

    public static bool operator ==(BnetInvitation a, BnetInvitation b)
    {
        return (object.ReferenceEquals(a, b) || (((a != null) && (b != null)) && (a.m_id == b.m_id)));
    }

    public static bool operator !=(BnetInvitation a, BnetInvitation b)
    {
        return !(a == b);
    }

    public void SetCreationTimeMicrosec(ulong microsec)
    {
        this.m_creationTimeMicrosec = microsec;
    }

    public void SetExpirationTimeMicroSec(ulong microsec)
    {
        this.m_expirationTimeMicrosec = microsec;
    }

    public void SetId(BnetInvitationId id)
    {
        this.m_id = id;
    }

    public void SetInviteeId(BnetAccountId id)
    {
        this.m_inviteeId = id;
    }

    public void SetInviteeName(string name)
    {
        this.m_inviteeName = name;
    }

    public void SetInviterId(BnetAccountId id)
    {
        this.m_inviterId = id;
    }

    public void SetInviterName(string name)
    {
        this.m_inviterName = name;
    }

    public void SetMessage(string message)
    {
        this.m_message = message;
    }

    public override string ToString()
    {
        if (this.m_id == null)
        {
            return "UNKNOWN INVITATION";
        }
        object[] args = new object[] { this.m_id, this.m_inviterId, this.m_inviterName, this.m_inviteeId, this.m_inviteeName, this.m_message };
        return string.Format("[id={0} inviterId={1} inviterName={2} inviteeId={3} inviteeName={4} message={5}]", args);
    }
}

