import numpy as np

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



def get_U(mat):
    count_columns = mat[0].size
    mat[0,:],mat[np.argmax(mat[:,0]),:] =mat[np.argmax(mat[:,0]),:].copy(), mat[0,:].copy()
    if count_columns == 1:
        return
    for k in range(0, count_columns):        
        for i in range(k+1, count_columns):
            mat[i, : ]  = list(mat[i, : ] - mat[i,k]*mat[k,:]/mat[k,k])

def get_L(mat_L, mat):
    count_columns = mat.shape[0]
    for k in range(count_columns):
        for i in range(k + 1, count_columns):
            mat_L[i, k] = (mat[i, k] - mat_L[i, : k] * mat_L[: k, k]) / mat_L[k, k]
    for i in range(mat_L.shape[0]):
            mat_L[i, i] = 1
            mat_L[i, i+1 :] = 0
    return np.matrix(mat_L)

def get_LU(mat):
    matA = mat.copy()
    mat_U = matA.copy()
    get_U(mat_U)
    mat_L = np.matrix(mat_U.copy())
    get_L(mat_L, mat)
    return mat_L, mat_U

def solve_by_LU(L,U,answ):
    n = L.shape[0]
    z = np.zeros(n)
    z[0] = answ[0]
    for i in range(1,n):
        tmp = 0
        for j in range(0,i):
            tmp+= L[i,j]*z[j]
            z[i] = answ[i] - tmp
    x = np.zeros(n)
    x[n-1] = z[n-1]/U[n-1,n-1]
    for i in range(n-2, -1, -1):
        tmp = 0
        for j in range(i+1,n):
            tmp += U[i,j]*x[j]
            x[i] = (z[i]-tmp)/U[i,i]
    return x

def solve(A,B):
    L,U = get_LU(A)
    return solve_by_LU(L,U,B)

def get_inverse_matrix(L,U):
    n = L.shape[0]
    res = np.zeros(n*n).reshape(n,n)
    E = np.eye(n)
    for i in range(0,n):
        y = solve_by_LU(L,E,E[i,:])
        x = solve_by_LU(E,U,y)
        for j in range(0,n):
            res[j,i] = x[j]
    return res

def get_det(mat_U):
    det = 1
    for i in range(0,mat_U.shape[0]):
        det *= mat_U[i,i]
    return det