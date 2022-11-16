using System;
using System.Collections.Generic;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{

    public class ConductingEquipment : Equipment
    {
        private List<long> terminals = new List<long>();
        public ConductingEquipment(long globalId) : base(globalId)
        {
        }

        public List<long> Terminals
        {
            get => terminals;
            set => terminals = value;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                ConductingEquipment x = (ConductingEquipment)obj;
                return CompareHelper.CompareLists(x.terminals, this.terminals);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {

                case ModelCode.CONDUCTINGEQUIPMENT_TERMINALS:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }
        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.CONDUCTINGEQUIPMENT_TERMINALS:
                    property.SetValue(terminals);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }
        public override bool IsReferenced
        {
            get
            {
                return terminals.Count != 0 || base.IsReferenced;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (Terminals != null && Terminals.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.CONDUCTINGEQUIPMENT_TERMINALS] = Terminals.GetRange(0, Terminals.Count);
            }

            base.GetReferences(references, refType);
        }
        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TERMINAL_CONDUCTING_EQUIPMENT:
                    Terminals.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }
        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.CONDUCTINGEQUIPMENT_TERMINALS:

                    if (Terminals.Contains(globalId))
                    {
                        Terminals.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }
    }
}
