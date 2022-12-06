using Common.MVP;

namespace UI.Popups.ConfirmationPopup
{
    public class ConfirmationPopupModel : BaseModel
    {
        public readonly string Description;

        public ConfirmationPopupModel(string description)
        {
            Description = description;
        }
    }
}