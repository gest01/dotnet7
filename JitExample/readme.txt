
dumpheap -type MyApp                                                                                                       
         Address               MT     Size
00007f94228098a8 00007fd43716c770       24     

Statistics:
              MT    Count    TotalSize Class Name
00007fd43716c770        1           24 JitExample.MyApp
Total 1 objects

> dumpmt -md 00007fd43716c770                                                                                                
EEClass:             00007FD43714F4D0
Module:              00007FD43713C428
Name:                JitExample.MyApp
mdToken:             0000000002000005
File:                /home/stef/projects/Pgo2/JitExample/bin/Debug/net7.0/JitExample.dll
AssemblyLoadContext: Default ALC - The managed instance of this context doesn't exist yet.
BaseSize:            0x18
ComponentSize:       0x0
DynamicStatics:      false
ContainsPointers:    false
Slots in VTable:     7
Number of IFaces in IFaceMap: 0
--------------------------------------
MethodDesc Table
           Entry       MethodDesc    JIT Name
00007FD436FF0048 00007FD436449290   NONE System.Object.Finalize()
00007FD436FF0060 00007FD4364492A0   NONE System.Object.ToString()
00007FD436FF0078 00007FD4364492B0   NONE System.Object.Equals(System.Object)
00007FD436FF00C0 00007FD4364492F0   NONE System.Object.GetHashCode()
00007FD43717E330 00007FD43716C760    JIT JitExample.MyApp..ctor()
00007FD43717E300 00007FD43716C730    JIT JitExample.MyApp.SayHello1()
00007FD43717E318 00007FD43716C748    JIT JitExample.MyApp.SayHello2()
>         


> dumpmd 00007FD43716C730                                                                                                    
Method Name:          JitExample.MyApp.SayHello1()
Class:                00007fd43714f4d0
MethodTable:          00007fd43716c770
mdToken:              0000000006000004
Module:               00007fd43713c428
IsJitted:             yes
Current CodeAddr:     00007fd4370941c0
Version History:
  ILCodeVersion:      0000000000000000
  ReJIT ID:           0
  IL Addr:            00007fd4b620d308
     CodeAddr:           00007fd4370941c0  (MinOptJitted)
     NativeCodeVersion:  0000000000000000
