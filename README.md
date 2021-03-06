# DevPlatform

developer  platform

## 目录结构说明

- deploy 构建、部署等脚本代码
- src 代码主目录
  - ClientApp 客户端应用目录
  - WebApp 浏览器应用目录
  - Microservice 需要单独部署的微服务目录，如IdentityServer等
  - Core 基础核心类库，包括基础库的扩展，辅助类以及实体模型等.
  - Share 共享类库，可在多个应用间共用的内容，如各类模型定义、通用配置、数据处理转换等，依赖 `Core`.
  - Http.API API接口项目，不限于Restful api.
  - Http.Application 应用功能类库，包括但不限于 仓储服务、消息服务、缓存服务等。依赖 `Share`.
  - Database 数据库目录，如EntityFramework数据库上下文及迁移项目.
  
- test 测试代码目录

## 开发说明

### 常规顺序

1. 定义实体
2. 数据库迁移同步
3. 编写服务，可直接实现，也可自定义接口规范，完全根据自身习惯和需求
4. 在应用中注入服务，通过调用各服务实现app逻辑
5. 将共用的部分抽象整理到Share项目中

### 基础原则

- `Core` 提供最低层级的辅助，意味着，封装第三方类库不要放到该项目中。这取决于你封装的对象被当成`服务`或`应用`，如果不明确，建议都当做`服务`处理。如，我封装第三方库编写自用的redis`帮助类`，可当成redis`服务`对外提供接口实现。

- 我们不建议拆分过多的项目，这样项目间的引用会变得难以追踪，实际编写代码时要多处切换。在`Services`项目中可以建立多级文件夹，编写各类功能，以服务的概念对应用层提供支持。

- `Share` 完全根据实际情况，将共用的内容放到该项目中，通常是一些通用的模型和配置，这些内容可能 会在多个`服务`或`应用`中被使用，而不是在应用层多次重复定义。

### 项目依赖关系

#### 结构

- app
  - | Services
    - | Share
      - | Entity
        - Assist
    - | EntityFrameworkCore
      - | Entity
        - Assist

#### 说明

- 应用层依赖于服务层(Services)
- 服务层依赖于`Share`和 `EntityFrameworkCore`
- `Share`和 `EntityFrameworkCore`依赖实体`Entity`。
- `Entity`依赖`Assist`。

该结构， `Entity`和`Assist`将被所有其他项目引用。

### 灵活

可灵活变动的地方在于，如果你不使用ef，或有多个数据来源，完全可以自己添加 数据层或数据查询项目，然后在服务层中去引用该数据层，实现对外提供的数据服务。

### 核心

`实体是核心`，一切从实体出发，实体贯穿整个应用，实体的定义就决定了应用的基础。也可以用现在流行的`领域`来理解。
`服务层`是开发实现的核心，是最需要被`良好设计`的层面，服务会多种多样
`应用层`尽可能保持简单，更重要的是处理 外部的数据提交以及对外提供需要的数据格式。
