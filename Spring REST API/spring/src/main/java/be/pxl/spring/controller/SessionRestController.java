package be.pxl.spring.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;


import be.pxl.spring.model.Session;
import be.pxl.spring.repository.*;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class SessionRestController {

	@Autowired
	private SessionRepository repo;
	
	@RequestMapping(method = RequestMethod.GET)
	public Session getSessionById(int id){		
		return repo.findOne(id);
		
	}
	@RequestMapping(method = RequestMethod.POST)
	public void updateSession(Session s){
		repo.save(s);
		
	}
}
