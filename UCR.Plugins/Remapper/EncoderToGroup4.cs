using HidWizards.UCR.Core.Attributes;
using HidWizards.UCR.Core.Models;
using HidWizards.UCR.Core.Models.Binding;

namespace HidWizards.UCR.Plugins.Remapper
{
    [Plugin("Encoder to Latching Group (4)", Group = "Encoder", Description = "Map from two inputs to latching group of 4")]
    [PluginInput(DeviceBindingCategory.Momentary, "Next")]
    [PluginInput(DeviceBindingCategory.Momentary, "Previous")]
    [PluginOutput(DeviceBindingCategory.Momentary, "Button1")]
    [PluginOutput(DeviceBindingCategory.Momentary, "Button2")]
    [PluginOutput(DeviceBindingCategory.Momentary, "Button3")]
    [PluginOutput(DeviceBindingCategory.Momentary, "Button4")]
    public class EncoderToGroup4 : BaseEncoderToGroup
    {
        public EncoderToGroup4() : base(4)
        {
        }
    }
}
