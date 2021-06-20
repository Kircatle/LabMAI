import numpy as np

"""Метод Рунге-Кутты"""
def runge_kutt(f, y0, z0, a, b, h):
    y = [y0]
    z = [z0]
    x = []
    i = 0
    for xi in np.arange(a,b+h,h):
        k = np.zeros(4)
        l = np.zeros(4)
        x.append(xi)
        for j in range(4):
            if j == 0:
                    l[j] = h * f(x[i], y[i], z[i])
                    k[j] = h * z[i]
            elif j == 3:
                    l[j] = h * f(x[i] + h, y[i] + k[j-1], z[i] + l[j-1])
                    k[j] = h * (z[i] + l[j-1])
            else:
                    l[j] = h * f(x[i] + 0.5*h, y[i] + 0.5 * k[j-1], z[i] + 0.5*l[j-1])
                    k[j] = h * (z[i] + 0.5*l[j-1])
        z.append(z[i] + (l[0] + 2 * (l[1] + l[2]) + l[3]) / 6)
        y.append(y[i] + (k[0] + 2 * (k[1] + k[2]) + k[3]) / 6)
        i+=1
    y.pop()
    z.pop()
    return x,y,z

def get_mat(file):
    mat = []
    answ = []
    with open(file) as file_handler:
        for line in file_handler:
            row = list(map(int, line.split(',')[:-1]))
            mat.append(row[:-1])
            answ.append([row[-1]])
        mat = np.asarray(mat)
        answ = np.asarray(answ).reshape(-1,1)
    return mat, answ

def get_PQ(mat,answ):
    P1 = -mat[0,1]/mat[0,0]
    Q1 = answ[0,0]/mat[0,0]
    size_mat = mat[:,0].size
    i = 1
    P = [P1]
    Q = [Q1]
    while i < size_mat-1:
        P.append(-mat[i,i+1]/(mat[i,i]+mat[i,i-1]*P[i-1]))
        Q.append((answ[i,0]-mat[i,i-1]*Q[i-1])/(mat[i,i]+mat[i,i-1]*P[i-1]))
        i+=1
    P.append(0)
    Q.append((answ[i,0]-mat[i,i-1]*Q[i-1])/(mat[i,i]+mat[i,i-1]*P[i-1]))
    return P, Q

def method(size_mat, P, Q):
    X = np.zeros(size_mat)
    X[size_mat-1] = Q[size_mat-1]
    i = size_mat-2
    while i > -1:
        X[i] = X[i+1]*P[i]+Q[i]
        i-=1
    return X


def run(mat, answ):
    size_mat = mat[:,0].size
    answ = np.asarray(answ).reshape(-1,1)
    P, Q = get_PQ(mat,answ)
    X = method(size_mat, P, Q)
    return X