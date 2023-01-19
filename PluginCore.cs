using System;
using Decal.Adapter;
using Decal.Adapter.Wrappers;
using Decal.Interop.Core;

namespace TestPlugin
{
    public class PluginCore : PluginBase
    {
        protected override void Startup()
        {
            Core.CharacterFilter.LoginComplete += CharacterFilter_LoginComplete;
        }

        protected override void Shutdown()
        {
            Core.CharacterFilter.LoginComplete -= CharacterFilter_LoginComplete;
        }

        private void CharacterFilter_LoginComplete(object sender, EventArgs e)
        {
            ///
            Log("Iterating over vitals...");
            foreach (var vital in Core.CharacterFilter.Vitals)
            {
                Log($"Vital: {vital.Name}; Base: {vital.Base}");
            }
            Log("...Done.");

            ///

            Log("Printing Vital Name by Index...");
            Log(Core.CharacterFilter.Vitals[CharFilterVitalType.Health].Name);
            Log(Core.CharacterFilter.Vitals[CharFilterVitalType.Stamina].Name);
            Log(Core.CharacterFilter.Vitals[CharFilterVitalType.Mana].Name);
            Log("...Done.");

            ///

            Decal.Interop.Filters.SkillInfo health = Core.CharacterFilter.Underlying.Vital[Decal.Interop.Filters.eVitalID.eHealth];
            Decal.Interop.Filters.SkillInfo stamina = Core.CharacterFilter.Underlying.Vital[Decal.Interop.Filters.eVitalID.eStamina];
            Decal.Interop.Filters.SkillInfo mana = Core.CharacterFilter.Underlying.Vital[Decal.Interop.Filters.eVitalID.eMana];

            Log("Iterating over vitals via Underlying...");
            Log($"Vital: {health.Name}; Base: {health.Base}");
            Log($"Vital: {stamina.Name}; Base: {stamina.Base}");
            Log($"Vital: {mana.Name}; Base: {mana.Base}");
            Log("...Done.");
        }

        private void Log(string message)
        {
            Host.Actions.AddChatText(message, 1);
        }
    }
}
