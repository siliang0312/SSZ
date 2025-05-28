[![.NET Core](https://github.com/ardalis/CleanArchitecture/workflows/.NET%20Core/badge.svg)](https://github.com/ardalis/CleanArchitecture/actions) [![Build Status](https://dev.azure.com/ssz031117/Pulse%20Core/_apis/build/status%2FThink0312.SSZ?branchName=master)](https://dev.azure.com/ssz031117/Pulse%20Core/_build/latest?definitionId=5&branchName=master)

这是一个基于 [.NET 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0) 与 [Ardalis.CleanArchitecture](https://github.com/ardalis/CleanArchitecture) 模板构建的示例项目，展示如何在实际业务中应用 **领域驱动设计（DDD）** 与 **CQRS 架构模式**，以实现设备维护流程建模。
---

## 📌 项目亮点

- ✅ 基于 **整洁架构** 模板构建（分层清晰）
- ✅ 使用 **领域驱动设计 DDD**，包括聚合根、值对象、领域服务、领域事件等
- ✅ 使用 **CQRS 模式**（命令/查询职责分离）
- ✅ 使用 **Specification 模式** 封装查询逻辑（基于 Ardalis.Specification）
- ✅ 事件建模驱动设计，聚焦实际业务流程

---

## 📚 模型设计

该项目基于以下事件建模图进行领域建模：

![事件建模图](https://github.com/user-attachments/assets/28f6c43b-15cb-471a-a96f-4c9c469a9662)

> 包括但不限于：维护项、维护计划、维护任务、维护记录等聚合

---

## 🧩 项目结构

src/

├── Core # 核心领域层（聚合、实体、值对象、枚举类、领域服务、领域事件、Specification、异常、接口、守卫）

├── UseCases # 用例层（CQRS、DTO）

├── Infrastructure # 基础设施层（EF Core、QueryService、Repository）

└── Web # 接口层（REPR模式）

tests/

├── FunctionalTests # 功能测试

├── IntegrationTests # 集成测试

└── UnitTests # 单元测试

---

## 🧪 技术栈

- **.NET 9 / C# 13**
- **EF Core 9** - 数据访问
- **MediatR** - 应用层中介器（CQRS）
- **Ardalis.Specification** - 规范模式
- **xUnit + NSubtitute + Autofixture** - 单元测试
- **FluentValidation** - 输入验证
- **EndPoints** - API
- **SmartEnum** - 枚举类
- **Ardalis.GuardClauses** - 守卫

---

## 🚀 快速开始

### 1️⃣ 克隆仓库

```bash
git clone https://github.com/Think0312/SSZ.git
cd SSZ
dotnet restore
dotnet build
dotnet run --project src/SSZ.Web
```

🧪 测试项目
```bash
dotnet test
```

