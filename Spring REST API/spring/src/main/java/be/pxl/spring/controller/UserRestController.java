package be.pxl.spring.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import be.pxl.spring.model.User;
import be.pxl.spring.repository.UserRepository;

@RestController
@RequestMapping(value="/session", produces="application/json")
public class UserRestController {

	@Autowired
	UserRepository repo;
	
	@RequestMapping(method = RequestMethod.GET)
	public User getUserById(int id){
		return repo.findOne(id);
	}
	@RequestMapping(method = RequestMethod.POST)
	public void updateUser(User u){
		repo.save(u);
	}
	
	
}
