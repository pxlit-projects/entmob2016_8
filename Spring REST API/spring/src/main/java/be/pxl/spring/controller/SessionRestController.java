package be.pxl.spring.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import be.pxl.spring.dao.SessionDao;
import be.pxl.spring.model.Session;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class SessionRestController {

	@Autowired
	private SessionDao dao;
	
	@RequestMapping(method = RequestMethod.GET)
	public Session getSessionById(int id){
		
		return dao.getSessionById(id);
		
		
	}
}
