
import os
import ctypes
import numpy

def test():
	print ("Test")
	return

os.chdir("../TestRunner/bin/Debug/")
img = ctypes.cdll.LoadLibrary("BurnSystems.Evolutionary.dll")
