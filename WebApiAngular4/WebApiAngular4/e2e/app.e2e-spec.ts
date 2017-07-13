import { WebApiAngular4Page } from './app.po';

describe('web-api-angular4 App', () => {
  let page: WebApiAngular4Page;

  beforeEach(() => {
    page = new WebApiAngular4Page();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
