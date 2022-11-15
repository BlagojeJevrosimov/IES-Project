using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Security.Cryptography;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public class Terminal : IdentifiedObject {
          
        private bool connected;

        private PhaseCode phases;
        
        private int sequenceNumber;

        private long conductingEquipment = 0;

        private List<long> transformerEnds;

        public Terminal(long globalId) : base(globalId)
        {
        }

        public  long ConductingEquipment {
            get {
                return this.conductingEquipment;
            }
            set {
                this.conductingEquipment = value;
            }
        }
                
        public  bool Connected {
            get {
                return this.connected;
            }
            set {
                this.connected = value;
            }
        }
        public  PhaseCode Phases {
            get {
                return this.phases;
            }
            set {
                this.phases = value;
            }
        } 
        public  int SequenceNumber {
            get {
                return this.sequenceNumber;
            }
            set {
                this.sequenceNumber = value;
            }
        }

        public List<long> TransformerEnds 
        { get => transformerEnds; 
         set => transformerEnds = value; 
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Terminal x = (Terminal)obj;
                return (x.conductingEquipment == this.conductingEquipment &&
                        x.phases == this.phases &&
                        x.connected == this.connected &&
                        x.sequenceNumber == this.sequenceNumber &&
                        CompareHelper.CompareLists(x.TransformerEnds, this.TransformerEnds)); 
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

                case ModelCode.TERMINAL_CONNECTED:
                case ModelCode.TERMINAL_SEQUENCE_NUMBER:
                case ModelCode.TERMINAL_PHASES:
                case ModelCode.TERMINAL_TRANSFORMER_ENDS:
                case ModelCode.TERMINAL_CONDUCTING_EQUIPMENT:
                    return true;
                default:
                    return base.HasProperty(t);

            }
        }
        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {

                case ModelCode.TERMINAL_CONNECTED:
                    property.SetValue(connected);
                    break;
                case ModelCode.TERMINAL_SEQUENCE_NUMBER:
                    property.SetValue(sequenceNumber);
                    break;
                case ModelCode.TERMINAL_PHASES:
                    property.SetValue((short)phases);
                    break;
                case ModelCode.TERMINAL_TRANSFORMER_ENDS:
                    property.SetValue(transformerEnds);
                    break;
                case ModelCode.TERMINAL_CONDUCTING_EQUIPMENT:
                    property.SetValue(conductingEquipment);
                    break;
                default:
                    base.GetProperty(property);
                    break;
            }
        }
        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.TERMINAL_CONNECTED:
                    connected = property.AsBool();
                    break;
                case ModelCode.TERMINAL_PHASES:
                    phases = (PhaseCode)property.AsEnum();
                    break;
                case ModelCode.TERMINAL_SEQUENCE_NUMBER:
                    sequenceNumber = property.AsInt();
                    break;
                case ModelCode.TERMINAL_CONDUCTING_EQUIPMENT:
                    conductingEquipment = property.AsReference();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }
        public override bool IsReferenced
        {
            get
            {
                return transformerEnds.Count != 0 || base.IsReferenced;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (TransformerEnds != null && TransformerEnds.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_TRANSFORMER_ENDS] = TransformerEnds.GetRange(0, TransformerEnds.Count);
            }
            else if (conductingEquipment != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TERMINAL_CONDUCTING_EQUIPMENT] = new List<long>();
                references[ModelCode.TERMINAL_CONDUCTING_EQUIPMENT].Add(conductingEquipment);
            }
            
            base.GetReferences(references, refType);
        }
        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TRANSFORMER_END_TERMINAL:
                    TransformerEnds.Add(globalId);
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
                case ModelCode.TERMINAL_TRANSFORMER_ENDS:

                    if (TransformerEnds.Contains(globalId))
                    {
                        TransformerEnds.Remove(globalId);
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
