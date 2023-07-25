//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class Manipulator : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Manipulator(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(Manipulator obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~Manipulator() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NoesisGUI_PINVOKE.delete_Manipulator(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public ulong touchDevice {
    set {
      NoesisGUI_PINVOKE.Manipulator_touchDevice_set(swigCPtr, value);
    } 
    get {
      ulong ret = NoesisGUI_PINVOKE.Manipulator_touchDevice_get(swigCPtr);
      return ret;
    } 
  }

  public Point position {
    set {
      NoesisGUI_PINVOKE.Manipulator_position_set(swigCPtr, ref value);
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.Manipulator_position_get(swigCPtr);
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<Point>(ret);
      }
      else {
        return new Point();
      }
    }

  }

  public Manipulator() : this(NoesisGUI_PINVOKE.new_Manipulator(), true) {
  }

}

}

