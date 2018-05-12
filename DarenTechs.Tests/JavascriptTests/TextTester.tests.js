//// <reference path="../DarenTechs.Web/wwwroot/js/DarenTechs.js" >

describe("DarenTechs.Modal.Text", function () {
    it("Should be able to get the same text out as in", function () {
        var result = new DarenTechs.Paragraph();

        result.setText("Hello");

        var t = result.getText();

        expect(result.getText()).toBe("Hello");
    });

        
  
});




