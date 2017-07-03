# opm2pmd

It converts .opm instrument data to .mml, following the PMD MML notation.

It requires [.NET Framework 4.5.2](https://www.microsoft.com/en-us/download/details.aspx?id=42642) or higher to run.

### Usage

Drag and drop your .opm files into this executable file, and it will output a .mml file accordingly.

### Description

This program will read the content of a .opm file, that should look roughly like this:

```javascript
@:0 CH1
//  LFRQ AMD PMD WF NFRQ
LFO:  31  64  64  0    0
// PAN FL CON AMS PMS SLOT NE
CH: 64  4   4   0   0  127  0
//  AR D1R D2R RR D1L  TL KS MUL DT1 DT2 AMS-EN
M1: 31   0   0  0   0  28  0   1   0   0      0
C1: 31  13   8 10   2   0  0   1   0   0      0
M2: 31   0   0  0   0  23  0   1   0   0      0
C2: 31  13   8 10   2   0  0   1   0   0      0
```

And write a .mml file, following the PMD MML notation, which will look like this:

```javascript
@  0   4   4  =CH1
  31   0   0   0   0  28   0   1   0   0
  31  13   8  10   2   0   0   1   0   0
  31   0   0   0   0  23   0   1   0   0
  31  13   8  10   2   0   0   1   0   0
```

(Note that annotations are removed in the process, and so is DT2, which is a OPM-only feature, thus not supported by the OPNA.)

Special thanks to [pedipanol](https://soundcloud.com/pedipanol/) for detailing the conversion process, and testing the software further than I did.