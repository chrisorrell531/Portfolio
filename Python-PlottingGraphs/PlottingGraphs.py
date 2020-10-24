#Programmed by Christopher Philip Orrell 24/05/2018.
#This script demonstrates graphs.

#Imports the numpy python library and the matplotlib python library.
import numpy as np
import matplotlib.pyplot as plt

#Set variables
names = ['A', 'B', 'C', 'D' ,'E', 'F', 'G']
values = [1, 10, 100, 25 , 48 , 15 , 90]

#Sets the size of each graph and the text and plots
plt.figure(figsize=(9, 4))

#Creates different graphs and values.
plt.subplot(131)
plt.bar(names, values)
plt.subplot(132)
plt.scatter(names, values)
plt.subplot(133)
plt.plot(names, values)
plt.suptitle('Different Graphs')
#Shows the created graphs.
plt.show()
