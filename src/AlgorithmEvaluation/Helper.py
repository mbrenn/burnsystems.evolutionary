def WriteToFile(array, filename):

    f = open(filename, "w")
    for v in array:
        f.write(str(v) + '\n')
    f.close()

    import os
    os.system(filename)

