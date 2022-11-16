namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;
    using System;

    /// <summary>
    /// PowerTransformerConverter has methods for populating
    /// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
    /// </summary>
    public static class PowerTransformerConverter
	{

        #region Populate ResourceDescription
        public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
        {
            if ((cimIdentifiedObject != null) && (rd != null))
            {
                if (cimIdentifiedObject.MRIDHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
                }
                if (cimIdentifiedObject.AliasNameHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_ALIAS_NAME, cimIdentifiedObject.AliasName));
                }
                if (cimIdentifiedObject.NameHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
                }
            }
        }

        public static void PopulatePowerTransformerEndProperties(FTN.PowerTransformerEnd cimPowerTransformerEnd, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimPowerTransformerEnd != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateTransformerEndProperties(cimPowerTransformerEnd, rd, importHelper, report);

                if (cimPowerTransformerEnd.BHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_B, cimPowerTransformerEnd.B));
                }
                if (cimPowerTransformerEnd.B0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_B0, cimPowerTransformerEnd.B0));
                }
                if (cimPowerTransformerEnd.ConnectionKindHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_CONNECTION_KIND, (short)GetDMSWindingConnection(cimPowerTransformerEnd.ConnectionKind)));
                }
                if (cimPowerTransformerEnd.GHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_G, cimPowerTransformerEnd.G));
                }
                if (cimPowerTransformerEnd.G0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_G0, cimPowerTransformerEnd.G0));
                }
                if (cimPowerTransformerEnd.PhaseAngleClockHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_PHASE_ANGLE_CLOCK, cimPowerTransformerEnd.PhaseAngleClock));
                }
                if (cimPowerTransformerEnd.RHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_R, cimPowerTransformerEnd.R));
                }
                if (cimPowerTransformerEnd.R0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_R0, cimPowerTransformerEnd.R0));
                }
                if (cimPowerTransformerEnd.RatedUHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_RATEDU, cimPowerTransformerEnd.RatedU));
                }
                if (cimPowerTransformerEnd.RatedSHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_RATEDS, cimPowerTransformerEnd.RatedS));
                }
                if (cimPowerTransformerEnd.XHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_X, cimPowerTransformerEnd.X));
                }
                if (cimPowerTransformerEnd.X0HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_END_X0, cimPowerTransformerEnd.X0));
                }
            }
        }
        public static void PopulateTransformerEndProperties(FTN.TransformerEnd cimTransformerEnd, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTransformerEnd != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTransformerEnd, rd);

                if (cimTransformerEnd.TerminalHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTransformerEnd.Terminal.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTransformerEnd.GetType().ToString()).Append(" rdfID = \"").Append(cimTransformerEnd.ID);
                        report.Report.Append("\" - Failed to set reference to Terminal: rdfID \"").Append(cimTransformerEnd.Terminal.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TRANSFORMER_END_TERMINAL, gid));

                }
            }
        }
        public static void PopulateRatioTapChangerProperties(FTN.RatioTapChanger cimRatioTapChanger, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimRatioTapChanger != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateTapChangerProperties(cimRatioTapChanger, rd);

                if (cimRatioTapChanger.StepVoltageIncrementHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RATIO_TAP_CHANGER_STEP_VOLTAGE_INCREMENT, cimRatioTapChanger.StepVoltageIncrement));
                }
                if (cimRatioTapChanger.TculControlModeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RATIO_TAP_CHANGER_TCUL_CONTROL_MODE, (short)GetTransformerControlMode(cimRatioTapChanger.TculControlMode)));
                }
                if (cimRatioTapChanger.TransformerEndHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimRatioTapChanger.TransformerEnd.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimRatioTapChanger.GetType().ToString()).Append(" rdfID = \"").Append(cimRatioTapChanger.ID);
                        report.Report.Append("\" - Failed to set reference to TransformerEnd: rdfID \"").Append(cimRatioTapChanger.TransformerEnd.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TRANSFORMER_END_TERMINAL, gid));
                }
            }

        }
        public static void PopulateTapChangerProperties(FTN.TapChanger cimTapChanger, ResourceDescription rd)
        {
            if ((cimTapChanger != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTapChanger, rd);

                if (cimTapChanger.HighStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_HIGH_STEP, cimTapChanger.HighStep));
                }
                if (cimTapChanger.InitialDelayHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_INITIAL_DELAY, cimTapChanger.InitialDelay));
                }
                if (cimTapChanger.LowStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_LOW_STEP, cimTapChanger.LowStep));
                }
                if (cimTapChanger.LtcFlagHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_LTC_FLAG, cimTapChanger.LtcFlag));
                }
                if (cimTapChanger.NeutralStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_NEUTRAL_STEP, cimTapChanger.NeutralStep));
                }
                if (cimTapChanger.NeutralUHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_NEUTRAL_U, cimTapChanger.NeutralU));
                }
                if (cimTapChanger.NormalStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_NORMAL_STEP, cimTapChanger.NormalStep));
                }
                if (cimTapChanger.RegulationStatusHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_REGULATION_STATUS, cimTapChanger.RegulationStatus));
                }
                if (cimTapChanger.SubsequentDelayHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TAP_CHANGER_SUBSEQUENT_DELAY, cimTapChanger.SubsequentDelay));
                }
            }

        }
        public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd)
        {
            if ((cimPowerSystemResource != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
            }

        }

        public static void PopulateTerminalProperties(FTN.Terminal cimTerminal, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTerminal != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTerminal, rd);

                if (cimTerminal.ConnectedHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONNECTED, cimTerminal.Connected));
                }
                if (cimTerminal.PhasesHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TERMINAL_PHASES, (short)GetDMSPhaseCode(cimTerminal.Phases)));
                }
                if (cimTerminal.SequenceNumberHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TERMINAL_SEQUENCE_NUMBER, (Int32)cimTerminal.SequenceNumber));
                }
                if (cimTerminal.ConductingEquipmentHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimTerminal.ConductingEquipment.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimTerminal.GetType().ToString()).Append(" rdfID = \"").Append(cimTerminal.ID);
                        report.Report.Append("\" - Failed to set reference to ConductingEquipment: rdfID \"").Append(cimTerminal.ConductingEquipment.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.TERMINAL_CONDUCTING_EQUIPMENT, gid));
                }
            }
        }

        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd)
        {
            if ((cimEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd);

                if (cimEquipment.AggregateHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_AGGREGATE, cimEquipment.Aggregate));
                }
                if (cimEquipment.NormallyInServiceHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.EQUIPMENT_NORMALLYINSERVICE, cimEquipment.NormallyInService));
                }
            }
        }

        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateEquipmentProperties(cimConductingEquipment, rd);

            }

        }

        public static void PopulatePowerTransformerProperties(FTN.PowerTransformer cimPowerTransformer, ResourceDescription rd)
        {
            if ((cimPowerTransformer != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateConductingEquipmentProperties(cimPowerTransformer, rd);

                if (cimPowerTransformer.VectorGroupHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.POWER_TRANSFORMER_VECTOR_GROUP, cimPowerTransformer.VectorGroup));
                }

            }
        }
        #endregion Populate ResourceDescription

        #region Enums convert
        public static PhaseCode GetDMSPhaseCode(FTN.PhaseCode phases)
        {
            switch (phases)
            {
                case FTN.PhaseCode.A:
                    return PhaseCode.A;
                case FTN.PhaseCode.AB:
                    return PhaseCode.AB;
                case FTN.PhaseCode.ABC:
                    return PhaseCode.ABC;
                case FTN.PhaseCode.ABCN:
                    return PhaseCode.ABCN;
                case FTN.PhaseCode.ABN:
                    return PhaseCode.ABN;
                case FTN.PhaseCode.AC:
                    return PhaseCode.AC;
                case FTN.PhaseCode.ACN:
                    return PhaseCode.ACN;
                case FTN.PhaseCode.AN:
                    return PhaseCode.AN;
                case FTN.PhaseCode.B:
                    return PhaseCode.B;
                case FTN.PhaseCode.BC:
                    return PhaseCode.BC;
                case FTN.PhaseCode.BCN:
                    return PhaseCode.BCN;
                case FTN.PhaseCode.BN:
                    return PhaseCode.BN;
                case FTN.PhaseCode.C:
                    return PhaseCode.C;
                case FTN.PhaseCode.CN:
                    return PhaseCode.CN;
                case FTN.PhaseCode.N:
                    return PhaseCode.N;
                case FTN.PhaseCode.s12N:
                    return PhaseCode.ABN;
                case FTN.PhaseCode.s1N:
                    return PhaseCode.AN;
                case FTN.PhaseCode.s2N:
                    return PhaseCode.BN;
                default:
                    return PhaseCode.Unknown;
            }
        }
        public static WindingConnection GetDMSWindingConnection(FTN.WindingConnection windingConnection)
        {
            switch (windingConnection)
            {
                case FTN.WindingConnection.A:
                    return WindingConnection.A;
                case FTN.WindingConnection.Yn:
                    return WindingConnection.Yn;
                case FTN.WindingConnection.Zn:
                    return WindingConnection.Zn;
                case FTN.WindingConnection.D:
                    return WindingConnection.D;
                case FTN.WindingConnection.I:
                    return WindingConnection.I;
                case FTN.WindingConnection.Z:
                    return WindingConnection.Z;
                case FTN.WindingConnection.Y:
                    return WindingConnection.Y;
                default:
                    return WindingConnection.Y;
            }

        }

        public static TransformerControlMode GetTransformerControlMode(FTN.TransformerControlMode transformerControlMode)
        {
            switch (transformerControlMode)
            {
                case FTN.TransformerControlMode.reactive:
                    return TransformerControlMode.REACTIVE;
                case FTN.TransformerControlMode.volt:
                    return TransformerControlMode.VOLT;
                default:
                    return TransformerControlMode.VOLT;
            }
        }
        #endregion Enums convert
    }
}
