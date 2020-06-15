﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Waterfall
{
  /// <summary>
  /// Transform rotation modifier
  /// </summary>
  public class EffectRotationModifier : EffectModifier
  {
    public FloatCurve xCurve;
    public FloatCurve yCurve;
    public FloatCurve zCurve;

    Quaternion baseRotation;
    public EffectRotationModifier()
    {
      xCurve = new FloatCurve();
      yCurve = new FloatCurve();
      zCurve = new FloatCurve();
    }
    public EffectRotationModifier(ConfigNode node) { Load(node); }

    public override void Load(ConfigNode node)
    {
      base.Load(node);
      xCurve = new FloatCurve();
      yCurve = new FloatCurve();
      zCurve = new FloatCurve();
      xCurve.Load(node.GetNode("xCurve"));
      yCurve.Load(node.GetNode("yCurve"));
      zCurve.Load(node.GetNode("zCurve"));
      modifierTypeName = this.GetType().Name;
    }
    public override ConfigNode Save()
    {
      ConfigNode node = base.Save();

      node.name = WaterfallConstants.RotationModifierNodeName;

      node.AddNode(Utils.SerializeFloatCurve("xCurve", xCurve));
      node.AddNode(Utils.SerializeFloatCurve("yCurve", yCurve));
      node.AddNode(Utils.SerializeFloatCurve("zCurve", zCurve));
      return node;
    }

    public override void Init(WaterfallEffect parentEffect)
    {
      base.Init(parentEffect);
      baseRotation = xforms[0].localRotation;
    }
    protected override void ApplyReplace(float strength)
    {
      for (int i = 0; i < xforms.Count; i++)
      {
        xforms[i].localRotation = Quaternion.LookRotation(new Vector3(xCurve.Evaluate(strength), yCurve.Evaluate(strength), zCurve.Evaluate(strength)));
      }
    }
    protected override void ApplyAdd(float strength)
    {
      for (int i = 0; i < xforms.Count; i++)
      {
        xforms[i].localRotation = Quaternion.LookRotation(new Vector3(xCurve.Evaluate(strength), yCurve.Evaluate(strength), zCurve.Evaluate(strength)));
      }
    }
    protected override void ApplySubtract(float strength)
    {
      for (int i = 0; i < xforms.Count; i++)
      {
        xforms[i].localRotation = Quaternion.LookRotation(new Vector3(xCurve.Evaluate(strength), yCurve.Evaluate(strength), zCurve.Evaluate(strength)));
      }
    }
    protected override void ApplyMultiply(float strength)
    {
      for (int i = 0; i < xforms.Count; i++)
      {
        xforms[i].localRotation = Quaternion.LookRotation(new Vector3(xCurve.Evaluate(strength), yCurve.Evaluate(strength), zCurve.Evaluate(strength)));
      }
    }
    
  }

}