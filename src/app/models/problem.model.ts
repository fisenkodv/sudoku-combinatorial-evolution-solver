export interface Problem {
  values: number[][];
}

// August 2014 MSDN article problem -- difficult
// solved using no = 200, me = 5000
export const DifficultProblem: Problem = {
  values: [
    [0, 0, 6, 2, 0, 0, 0, 8, 0],
    [0, 0, 8, 9, 7, 0, 0, 0, 0],
    [0, 0, 4, 8, 1, 0, 5, 0, 0],
    [0, 0, 0, 0, 6, 0, 0, 0, 2],
    [0, 7, 0, 0, 0, 0, 0, 3, 0],
    [6, 0, 0, 0, 5, 0, 0, 0, 0],
    [0, 0, 2, 0, 4, 7, 1, 0, 0],
    [0, 0, 3, 0, 2, 8, 4, 0, 0],
    [0, 5, 0, 0, 0, 1, 2, 0, 0]
  ]
};

//// http://ieeexplore.ieee.org/stamp/stamp.jsp?tp=&arnumber=5412260
//// very difficult.
//// solved using no = 200, me = 9000
export const VeryDifficultProblem: Problem = {
  values: [
    [0, 0, 0, 0, 7, 0, 0, 0, 0],
    [0, 9, 0, 5, 0, 6, 0, 8, 0],
    [0, 0, 8, 4, 0, 1, 2, 0, 0],
    [0, 5, 9, 0, 0, 0, 8, 4, 0],
    [7, 0, 0, 0, 0, 0, 0, 0, 6],
    [0, 2, 3, 0, 0, 0, 5, 7, 0],
    [0, 0, 5, 3, 0, 7, 4, 0, 0],
    [0, 1, 0, 6, 0, 8, 0, 9, 0],
    [0, 0, 0, 0, 1, 0, 0, 0, 0]
  ]
};

//// easy
//// solved quickly with almost any reasonable no, me
export const EasyProblem: Problem = {
  values: [
    [0, 0, 7, 0, 0, 2, 9, 3, 0],
    [0, 8, 1, 0, 0, 0, 0, 0, 5],
    [9, 0, 4, 7, 0, 0, 1, 6, 0],
    [0, 1, 0, 8, 0, 0, 0, 0, 6],
    [8, 4, 6, 0, 0, 0, 5, 9, 2],
    [5, 0, 0, 0, 0, 6, 0, 1, 0],
    [0, 9, 2, 0, 0, 8, 3, 0, 1],
    [4, 0, 0, 0, 0, 0, 6, 5, 0],
    [0, 6, 5, 4, 0, 0, 2, 0, 0]
  ]
};

//// http://elmo.sbs.arizona.edu/sandiway/sudoku/examples.html
//// EXTREMELY difficult.
//// solved quickly using no = 100, me = 19,000
export const ExtremelyDifficultProblem: Problem = {
  values: [
    [0, 0, 0, 6, 0, 0, 4, 0, 0],
    [7, 0, 0, 0, 0, 3, 6, 0, 0],
    [0, 0, 0, 0, 9, 1, 0, 8, 0],
    [0, 0, 0, 0, 0, 0, 0, 0, 0],
    [0, 5, 0, 1, 8, 0, 0, 0, 3],
    [0, 0, 0, 3, 0, 6, 0, 4, 5],
    [0, 4, 0, 2, 0, 0, 0, 6, 0],
    [9, 0, 3, 0, 0, 0, 0, 0, 0],
    [0, 2, 0, 0, 0, 0, 1, 0, 0]
  ]
};

//// http://elmo.sbs.arizona.edu/sandiway/sudoku/examples.html
//// most difficult problem found by Internet search.
//// solved eventually using no = 100, me = 5,000.
//// solution when seed = 577 (i.e., 577 attempts ~ 20 min.)
export const Difficult1Problem: Problem = {
  values: [
    [0, 2, 0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 6, 0, 0, 0, 0, 3],
    [0, 7, 4, 0, 8, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 3, 0, 0, 2],
    [0, 8, 0, 0, 4, 0, 0, 1, 0],
    [6, 0, 0, 5, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 1, 0, 7, 8, 0],
    [5, 0, 0, 0, 0, 9, 0, 0, 0],
    [0, 0, 0, 0, 0, 0, 0, 4, 0]
  ]
};
