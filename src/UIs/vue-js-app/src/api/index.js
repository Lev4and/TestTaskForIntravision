import axios from "axios";

class ApiResponse {
  constructor(result = null, code = null, message = null, exception = null) {
    this.code = code;
    this.result = result;
    this.message = message;
    this.exception = exception;
  }

  get isError() {
    return this.code >= 400 || !!this.exception;
  }
}

class RequestHandler {
  async handle(request) {
    try {
      const response = await request;
      return new ApiResponse(
        response?.data?.result,
        response?.data?.code,
        response?.data?.message,
        response?.data?.exception
      );
    } catch (error) {
      return new ApiResponse(
        error.response?.data?.result,
        error.response?.status,
        error.message,
        error
      );
    }
  }
}

class HttpClient {
  constructor(baseUrl) {
    this.axios = axios.create({
      baseURL: baseUrl,
    });
    this.requestHandler = new RequestHandler();
  }

  async get(url = "") {
    return await this.requestHandler.handle(this.axios.get(url));
  }

  async post(url = "", data = null) {
    return await this.requestHandler.handle(this.axios.post(url, data));
  }

  async put(url = "", data = null) {
    return await this.requestHandler.handle(this.axios.put(url, data));
  }

  async delete(url = "") {
    return await this.requestHandler.handle(this.axios.delete(url));
  }
}

class ApiHttpClient extends HttpClient {
  constructor(path) {
    super(`https://${window.location.hostname}:44318/api/${path}`);
  }
}

class CoinsApiHttpClient extends ApiHttpClient {
  constructor() {
    super("coins/v1/");
  }
}

class BeveragesApiHttpClient extends ApiHttpClient {
  constructor() {
    super("beverages/v1/");
  }

  async buy(coins, beverages) {
    return super.post("buy", {
      depositedCoins: coins,
      selectedBeverages: beverages,
    });
  }
}

class Api {
  constructor() {
    this.coins = new CoinsApiHttpClient();
    this.beverages = new BeveragesApiHttpClient();
  }
}

export const api = new Api();
