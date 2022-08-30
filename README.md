# coverlet-issue-poc

1. Run all tests but get zero line coverage

```
dotnet test .\CalculatorTests\CalculatorTests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura
```
Result:

```
+------------+------+--------+--------+
| Module     | Line | Branch | Method |
+------------+------+--------+--------+
| Calculator | 0%   | 100%   | 0%     |
+------------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 0%   | 100%   | 0%     |
+---------+------+--------+--------+
| Average | 0%   | 100%   | 0%     |
+---------+------+--------+--------+
```

2. Exclude the troublesome test case and get 100% line coverage

```
dotnet test .\CalculatorTests\CalculatorTests.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura --filter TestCategory!=TroubleMaker
```

Result:
```
+------------+------+--------+--------+
| Module     | Line | Branch | Method |
+------------+------+--------+--------+
| Calculator | 100% | 100%   | 100%   |
+------------+------+--------+--------+

+---------+------+--------+--------+
|         | Line | Branch | Method |
+---------+------+--------+--------+
| Total   | 100% | 100%   | 100%   |
+---------+------+--------+--------+
| Average | 100% | 100%   | 100%   |
+---------+------+--------+--------+
```