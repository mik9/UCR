using HidWizards.UCR.Core.Attributes;
using HidWizards.UCR.Core.Models;
using HidWizards.UCR.Core.Models.Binding;

namespace HidWizards.UCR.Plugins.Remapper
{
    public abstract class BaseEncoderToGroup : Plugin
    {
        [PluginGui("Latching", Order = 0)]
        public bool Latching { get; set; }

        private short maxButtons;
        private short button = -1;

        public BaseEncoderToGroup(short maxButtons) 
        {
            Latching = true;
            this.maxButtons = maxButtons;
        }

        public override void OnActivate()
        {
            if (button == -1)
            {
                button = 0;
            }
            if (Latching) 
            {
                WriteOutput(button, 1);
            }
        }

        public override void OnDeactivate()
        {
            for (int i = 0; i < maxButtons; i++)
            {
                WriteOutput(i, 0);
            }
        }

        public override void Update(params short[] values)
        {   
            if (Latching)
            {
                UpdateLatching(values);
            }
            else
            {
                UpdateMomentary(values);
            }
        }

        private void HandleNext()
        {
            if (button < maxButtons - 1)
            {
                button++;
            }
        }

        private void HandlePrev()
        {
            if (button > 0)
            {
                button--;
            }
        }

        private void UpdateLatching(params short[] values)
        {
            var prev_button = button;
            if (values[0] == 1)
            {
                HandleNext();
            }
            else if (values[1] == 1)
            {
                HandlePrev();
            }

            if (prev_button != button)
            {
                WriteOutput(prev_button, 0);
                WriteOutput(button, 1);
            }
        }

        private void UpdateMomentary(params short[] values)
        {
            bool press = false;
            if (values[0] == 1)
            {
                press = true;
                HandleNext();
            }
            else if (values[1] == 1)
            {
                press = true;
                HandlePrev();
            }

            if (press)
            {
                WriteOutput(button, 1);
            }
            else
            {
                WriteOutput(button, 0);
            }
        }
    }
}
